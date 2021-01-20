// Get URL Parameters - Relative protocol, domain, port
let url = window.location.href;
let arr = url.split("/");
let result = arr[0] + "//" + arr[2];
let APPIQUERYURL = result;
let ACCOUNTAPPIQUERYURL = "https://ecoauth.strangeloopgames.com/";

function getURLParameter(name) {
	return decodeURIComponent((new RegExp('[?|&]' + name + '=' + '([^&;]+?)(&|#|;|$)').exec(location.search)||[,""])[1].replace(/\+/g, '%20'))||null
}

String.prototype.escapeQuotes = function() {
    return this.replace(/(["'])/g, "\\$1");
};

String.prototype.strip = function() {
    let tmp = document.implementation.createHTMLDocument("New").body;
    tmp.innerHTML = this;
    return tmp.textContent || tmp.innerText || "";
};

/**
 * Recursive method for clearing vars of any types from XSS attacks
 */
function clearFromXSS(data) {
    // Removing all <script tags
    let pattern = /<script\b[^<]*(?:(?!<\/script>)<[^<]*)*<\/script>/gi;

    if (typeof data == 'string') {
        return data.replace(pattern, '');
    }

    if (Array.isArray(data)) {
        return data.map(clearFromXSS);
    }

    if (typeof data == 'object') {
        for (let key in data) {
            data[key] = clearFromXSS(data[key]);
        }
    }

    return data;
}