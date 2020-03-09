// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

window.utils = {
    serializeFormObject: function (querySelector) {
        let ret = {};
        $(querySelector).serializeArray().map((v, k) => {
            let name = v.name;
            if (name.match(/\[\]$/)) {
                name = name.substr(0, name.length - 2);
                if (typeof ret[name] === "undefined") {
                    ret[name] = [];
                }
                ret[name].push(v.value);
            } else {
                ret[name] = v.value;
            }

        });
        return ret;

    },
};