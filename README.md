# dropzoneDemo
dropzone简单学习

## 效果图
![](https://github.com/zc282840325/dropzoneDemo/blob/master/dropzone/Resource/2.png)

## html部分

<div class="row" style="margin-top:50px;">
        <div class="col-md-4 form-group m-form__group row">
            <label asp-for="Avatar" class="col-form-label col-md-3"> 上传账号 </label>
            <div class="col-md-9">
                @*<input id="Avatar" type="hidden" />*@
                <input id="PictureFileToken" type="hidden" />
                <input id="PictureId" type="hidden" />
                <div class="dropzone m-dropzone m-dropzone--success" id="m-dropzone-one" action="/Home/UpLoadProcess">
                </div>
            </div>
        </div>
</div>
<input type="text"  id="Avatar" readonly/>
