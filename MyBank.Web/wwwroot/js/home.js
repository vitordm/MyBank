
class MyBankViewModel {

    constructor() {
    }

    initApp() {


        this.setBindLinksActions();

        const conta = localStorage.getItem('account');
        if (!conta) {
            this.disableLinks();
            return;
        }

        this.inicializarConta(JSON.parse(conta));


        this.enableLinks();
    }

    inicializarConta(conta) {
        this.account = conta;
        this.exibirDadosConta();
        this.carregarExtrato();
    }

    salvarConta(conta) {
        localStorage.setItem('account', JSON.stringify(conta));
    }

    disableLinks() {
        $('.app-link-nav').attr('aria-disabled', 'true');
    }

    enableLinks() {
        $('.app-link-nav').attr('aria-disabled', 'false');
    }

    exibirDadosConta() {
        $('#app-dados-conta').removeClass('d-none');
        $('#app-dados-conta').html(`
        <h6>Agência: ${this.account.branch}</h6>
        <h6>Conta: ${this.account.account}</h6>
        <h6>Digíto: ${this.account.digit}</h6>
        <h6>Cliente: ${this.account.customer}</h6>
        <h6>Saldo: ${this.account.totalBalance}</h6> 
`)
    }

    setBindLinksActions() {
        $('#link-extrato').click((event) => {
            this.carregarExtrato();
        });

        $('#link-deposito').click((event) => {
            this.linkDeposito();
        });
        $('#link-retirada').click((event) => {
            this.linkRetirada();
        });
        $('#link-pagamentos').click((event) => { });
        $('#link-acessarconta').click((event) => {
            this.linkAcessarConta();
        });
    }

    linkAcessarConta() {
        const html = `
        <form id="app-form-acessarconta">
            <div class="row">
                <div class="col-12 form-group">
                    <input type="text" class="form-control" placeholder="Agência" name="agencia">
                </div>
                <div class="col-12 form-group">
                    <input type="text" class="form-control" placeholder="Conta" name="conta">
                </div>
                <div class="col-12 form-group">
                    <input type="text" class="form-control" placeholder="Digito" name="digito">
                </div>
                <div class="col-12 form-group">
                    <input type="password" class="form-control" placeholder="Senha" name="senha">
                </div>
            </div>
        </form>`;

        var dialog = bootbox.dialog({
            title: 'Acessar conta',
            message: html,
            size: 'small',
            buttons: {
                cancel: {
                    label: "Cancelar",
                    className: 'btn-danger',
                    callback: function () {
                        console.log('Custom cancel clicked');
                    }
                },
                ok: {
                    label: "Prosseguir",
                    className: 'btn-success',
                    callback: () => {
                        //$('#app-form-acessarconta').serializeArray();
                        const form = utils.serializeFormObject('#app-form-acessarconta');
                        this.carregarDadosConta(form)
                    }
                }
            }
        });
    }

    linkDeposito() {
        if (!this.account)
            return;

        const html = `
        <form id="app-form-deposito">
            <div class="row">
                <div class="col-12 form-group">
                    <input type="text" class="form-control" placeholder="Depositante" name="depositante">
                </div>
                <div class="col-12 form-group">
                    <input type="number" class="form-control" placeholder="Valor" name="valor" step="0.50" min="0" max="2000">
                </div>
            </div>
        </form>`;

        var dialog = bootbox.dialog({
            title: 'Depósito',
            message: html,
            size: 'small',
            buttons: {
                cancel: {
                    label: "Cancelar",
                    className: 'btn-danger',
                    callback: function () {
                        console.log('Custom cancel clicked');
                    }
                },
                ok: {
                    label: "Prosseguir",
                    className: 'btn-success',
                    callback: () => {
                        //$('#app-form-acessarconta').serializeArray();
                        const form = utils.serializeFormObject('#app-form-deposito');
                        this.realizarDeposito(form);
                    }
                }
            }
        });
    }

    linkRetirada() {

        const html = `
        <form id="app-form-retirada">
            <div class="row">
                <div class="col-12 form-group">
                    <input type="number" class="form-control" placeholder="Valor" name="valor" step="0.50" min="0" max="2000">
                </div>
            </div>
        </form>`;

        var dialog = bootbox.dialog({
            title: 'Depósito',
            message: html,
            size: 'small',
            buttons: {
                cancel: {
                    label: "Cancelar",
                    className: 'btn-danger',
                    callback: function () {
                        console.log('Custom cancel clicked');
                    }
                },
                ok: {
                    label: "Prosseguir",
                    className: 'btn-success',
                    callback: () => {
                        //$('#app-form-acessarconta').serializeArray();
                        const form = utils.serializeFormObject('#app-form-retirada');
                        this.realizarRetirada(form);
                    }
                }
            }
        });
    }

    realizarDeposito(form) {
        const data = {
            "depositorName": form.depositante,
            "branch": this.account.branch,
            "account": this.account.account,
            "digit": this.account.digit,
            "amount": form.valor
        };

        axios.post('/api/bank/deposit', data)
            .then((response) => {
                this.carregarInfoConta();
                this.carregarExtrato();
            })
            .catch((error) => {
                bootbox.alert(`Ocorreu um erro: ${error.response.data}`);
            });
    }

    realizarRetirada(form) {
        const data = {
            "branch": this.account.branch,
            "account": this.account.account,
            "digit": this.account.digit,
            "amount": (form.valor * -1)
        };

        axios.post('/api/bank/withdraw', data)
            .then((response) => {
                this.carregarExtrato();
                this.carregarInfoConta();
            })
            .catch((error) => {
                bootbox.alert(`Ocorreu um erro: ${error.response.data}`);
            });

    }

    carregarDadosConta(form) {
        const data = {
            "branch": form.agencia,
            "account": form.conta,
            "digit": form.digito,
            "authorizationPass": form.senha
        }
        axios.post('/api/Bank/Account', data)
            .then((response) => {
                const conta = response.data;
                this.salvarConta(conta);
                this.inicializarConta(conta);
            })
            .catch((error) => {
                if (error.response.status == 404) {
                    bootbox.alert(`Conta não encontrada!`);
                    return;
                }
                bootbox.alert(`Ocorreu um erro: ${error.response.data}`);
            })



    }

    carregarExtrato() {
        if (!this.account)
            return;

        axios.get(`/api/Bank/AccountTransactions?accountUid=${this.account.uid}`)
            .then(response => {
                const transactions = response.data;

                let htmlLinhas = '';
                for (let transaction of transactions) {
                    let htmlLinha = `<tr>
                                    <td>${transaction.createDate}</td>
                                    <td>${transaction.description}</td>
                                    <td>${transaction.amount.toLocaleString('pt-BR', { minimumFractionDigits: 2 })}</td>
                                </tr>
`;
                    htmlLinhas += htmlLinha;
                }

                let htmlTable = `

<div class="col-12 overflow-auto" style="max-height: 700px">
<h5>Extrato</h5>
    <table class="table table-striped table-bordered table-condensed">
    <thead>
         <tr>
            <th>Data</th>
            <th>Descrição</th>
            <th>Valor</th>
        </tr>
    </thead>
    </tbody>
    ${htmlLinhas}
    </tbody>
    </table>
</div>`

                $('#app-content').html(htmlTable);
            })
    }

    carregarInfoConta() {
        axios.get(`/api/bank/account?accountUid=${this.account.uid}`)
            .then(response => {
                this.account = response.data;
                this.salvarConta(response.data);
                this.exibirDadosConta();
            })
    }

}

window.pageViewModel = new MyBankViewModel()