+function () {
    if (!window.Dropzone) {
        return;
    }

    var options = {
        paramName: "file",
        dictDefaultMessage: "拖放文件上传",
        dictFallbackMessage: "您的浏览器不支持拖放文件上传",
        dictFallbackText: "您的浏览器不支持拖放文件上传,请使用表单上传文件",
        dictFileTooBig: "文件太大了 ({{filesize}}MiB). 文件大小: {{maxFilesize}}MiB.",
        dictInvalidFileType: "文件类型错误!",
        dictResponseError: "服务端返回 {{statusCode}} .",
        dictCancelUpload: "取消文件上传",
        dictUploadCanceled: "文件上传已取消",
        dictCancelUploadConfirmation: "确定取消上传操作吗?",
        dictRemoveFile: "移除文件",
        dictMaxFilesExceeded: "最多只能上传 {{maxFiles}} 个文件",
        // 移除文件操作链接
        addRemoveLinks: true,
        headers: {},
        maxfilesexceeded: function (file) {
            this.removeFile(file);
            abp.message.warn("最多只能上传 " + this.options.maxFiles + " 个文件");
        }
    };

    var token = abp.security.antiForgery.getToken();
    if (token) {
        options.headers[abp.security.antiForgery.tokenHeaderName] = token;
    }

    Dropzone.extend(Dropzone.prototype.defaultOptions, options);

}()