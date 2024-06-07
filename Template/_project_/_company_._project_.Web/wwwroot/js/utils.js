function dtajax(settings) {
    var callback = (settings.success !== undefined && typeof settings.success === 'function')
        ? settings.success
        : function (res) { };
    var fcallback = (settings.fail !== undefined && typeof settings.fail === 'function')
        ? settings.fail
        : function (res) {
            layer.alert(res.msg, {
                icon: 5,
                title: '错误提示'
            });
        };
    var ecallback = (settings.error !== undefined && typeof settings.error === 'function')
        ? settings.error
        : function (xmlHttpRequest) {
            var msg = 'code:' + xmlHttpRequest.status + '<br/>' + 'message:' + xmlHttpRequest.responseText;
            layer.alert(msg, {
                icon: 5,
                title: 'ajax请求失败'
            });
        };
    settings.success = function (res) {
        console.log(res);
        layer.closeAll();
        zeroModal.closeAll();
        if (res.status) {
            callback(res);
        } else {
            fcallback(res);
        }
    };
    settings.type = settings.type !== undefined ? settings.type : 'POST';
    settings.error = function (xmlHttpRequest, textStatus, errorThrown) {
        layer.closeAll();
        zeroModal.closeAll();
        console.log(xmlHttpRequest);
        console.log(textStatus);
        console.log(errorThrown);
        ecallback(xmlHttpRequest);
    };
    //layer.load(1);
    zeroModal.loading(2);
    console.log(settings);
    $.ajax(settings);
}

// 局部刷新视图
function goHash(callback) {
    var $load = $("#js-dtdata-body");
    if (window.location.hash.length > 1) {
        var ts = new Date().getTime();
        var url = window.location.hash.substr(1, window.location.hash.length - 1);
        if (url.indexOf('?') > -1)
            url = url + "&ts=" + ts;
        else
            url = url + "?ts=" + ts;
        layer.closeAll();
        zeroModal.closeAll();
        //layer.load(1);
        zeroModal.loading(2);
        $.ajax({
            url: url,
            success: function (res) {
                layer.closeAll();
                zeroModal.closeAll();
                if (res.status === false) {
                    $load.html("");
                    layer.alert(res.msg, {
                        icon: 5,
                        title: '错误提示'
                    });
                    return;
                }
                $load.html(res);
                if (typeof callback === 'function') {
                    callback();
                }
            }
        });
    }
}

// 分页
function initPage(cur, total, url) {
    $('#pagination').pagination({
        pages: total, //总页数
        edges: 2,
        currentPage: cur,
        cssStyle: 'pagination-sm', //按纽大小pagination-lg或写入自定义css
        displayedPages: 5, //显示几个
        onPageClick: function (pageNumber, event) {
            //点击时调用
            location.hash = url + "page=" + pageNumber;
        },
        onInit: function (getid) {
            //刷新时或初始化调用
        }
    });
}

// 复制
function copyText(id) {
    var dom = document.getElementById(id);
	dom.select(); // 选择对象
	document.execCommand("Copy"); // 执行浏览器复制命令
	layer.msg("已复制好，可贴粘。");
}

// 格式化json
function formatJson(json, options) {
    var reg = null,
        formatted = '',
        pad = 0,
        PADDING = '    '; // one can also use '\t' or a different number of spaces

    // optional settings
    options = options || {};
    // remove newline where '{' or '[' follows ':'
    options.newlineAfterColonIfBeforeBraceOrBracket = (options.newlineAfterColonIfBeforeBraceOrBracket === true) ? true : false;
    // use a space after a colon
    options.spaceAfterColon = (options.spaceAfterColon === false) ? false : true;

    // begin formatting...
    if (typeof json !== 'string') {
        // make sure we start with the JSON as a string
        json = JSON.stringify(json);
    } else {
        // is already a string, so parse and re-stringify in order to remove extra whitespace
        json = JSON.parse(json);
        json = JSON.stringify(json);
    }

    // add newline before and after curly braces
    reg = /([\{\}])/g;
    json = json.replace(reg, '\r\n$1\r\n');

    // add newline before and after square brackets
    reg = /([\[\]])/g;
    json = json.replace(reg, '\r\n$1\r\n');

    // add newline after comma
    reg = /(\,)/g;
    json = json.replace(reg, '$1\r\n');

    // remove multiple newlines
    reg = /(\r\n\r\n)/g;
    json = json.replace(reg, '\r\n');

    // remove newlines before commas
    reg = /\r\n\,/g;
    json = json.replace(reg, ',');

    // optional formatting...
    if (!options.newlineAfterColonIfBeforeBraceOrBracket) {
        reg = /\:\r\n\{/g;
        json = json.replace(reg, ':{');
        reg = /\:\r\n\[/g;
        json = json.replace(reg, ':[');
    }
    if (options.spaceAfterColon) {
        reg = /\:/g;
        json = json.replace(reg, ':');
    }

    $.each(json.split('\r\n'), function (index, node) {
        var i = 0,
            indent = 0,
            padding = '';

        if (node.match(/\{$/) || node.match(/\[$/)) {
            indent = 1;
        } else if (node.match(/\}/) || node.match(/\]/)) {
            if (pad !== 0) {
                pad -= 1;
            }
        } else {
            indent = 0;
        }

        for (i = 0; i < pad; i++) {
            padding += PADDING;
        }

        formatted += padding + node + '\r\n';
        pad += indent;
    });

    return formatted;
}

// 判断字符数量
function charNum(str, c) {
	return (str.split(c)).length - 1;
}

// 判断行数
function strLine(str) {
	return str.split(/\r\n|\r|\n/).length;
}
