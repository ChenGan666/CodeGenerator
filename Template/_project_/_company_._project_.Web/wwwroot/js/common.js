
function TCommon() {
  
}

TCommon.prototype.init = function () {

 

};

TCommon.prototype.dedupe = function (array) {
    return Array.from(new Set(array));
};

// 提交模板
TCommon.prototype.formAutoSave = function (form, url, func) {

    form.on('submit(save)', function (data) {
        layer.load(5);
        if (func !== undefined && typeof func === "function") {
            data = func(data);
        }
        console.log(data);
        dtajax({
            url: url,
            type: 'POST',
            data: data.field,
            success: function (res) {
                // 关闭loading
                layer.closeAll();
                //关闭当前frame
                xadmin.close();
                // 可以对父窗口进行刷新
                xadmin.father_reload();
            }
        });
        return false;
    });

};

 
 

var Common = new TCommon();
$(document).ready(function () {

    Common.init();
});