/* Demo Note:  This demo uses a FileProgress class that handles the UI for displaying the file name and percent complete.
The FileProgress class is not part of SWFUpload.
*/


/* **********************
   Event Handlers
   These are my custom event handlers to make my
   web application behave the way I went when SWFUpload
   completes different tasks.  These aren't part of the SWFUpload
   package.  They are part of my application.  Without these none
   of the actions SWFUpload makes will show up in my application.
   ********************** */
function fileQueued(file) {
	try {

	    fileprogress.addUploadItem(file, this.customSettings.progressTarget);
	    fileprogress.bindCancelUpload(file, this);
	    $("#" + this.customSettings.progressBarDiv).show();

	} catch (ex) {
		this.debug(ex);
	}

}

function fileQueueError(file, errorCode, message) {
	try {
		if (errorCode === SWFUpload.QUEUE_ERROR.QUEUE_LIMIT_EXCEEDED) {
			App.alert("�����ϴ����������ϴ�");
			return;
		}
		switch (errorCode) {
		case SWFUpload.QUEUE_ERROR.FILE_EXCEEDS_SIZE_LIMIT:
		    App.alert("�ļ�����10M");
			break;
		case SWFUpload.QUEUE_ERROR.ZERO_BYTE_FILE:
		    App.alert("�����ϴ�0�ֽڵ��ļ�");
			break;
		case SWFUpload.QUEUE_ERROR.INVALID_FILETYPE:
		    App.alert("������ȷ��MP3��Ƶ�ļ�");
			break;
		default:
			if (file !== null) {
			    App.alert("δ֪����");
			}
			break;
		}
	} catch (ex) {
        this.debug(ex);
    }
}

function fileDialogComplete(numFilesSelected, numFilesQueued) {
	try {
		this.startUpload();
	} catch (ex)  {
        this.debug(ex);
	}
}

function uploadStart(file) {
	try {
	    fileprogress.setUploadPercent(file,0);
	}
	catch (ex) {}
	
	return true;
}

function uploadProgress(file, bytesLoaded, bytesTotal) {
	try {
		var percent = Math.ceil((bytesLoaded / bytesTotal) * 100);

		fileprogress.setUploadPercent(file, percent);
	} catch (ex) {
		this.debug(ex);
	}
}

function uploadSuccess(file, serverData) {
    try {
        var json = eval("("+serverData+")");
        if (json != null) {
            if (json.Code == "A00008") {
                App.tip(CodeList[json.Code],1000);
                
                App.insertTxt2Txtarea(this.customSettings.txtArea,json.Data);
            }
            else {
                App.alert(CodeList[json.Code]);
            }
        }
        else {
            App.alert(CodeList["A00003"]);
        }
        $("#" + this.customSettings.musicDiaDiv).hide();
        $("#" + this.customSettings.progressBarDiv).hide();

	} catch (ex) {
        this.debug(ex);
        App.alert(CodeList["A00003"]);
        $("#" + this.customSettings.musicDiaDiv).hide();
        $("#" + this.customSettings.progressBarDiv).hide();
	}
}

function uploadError(file, errorCode, message) {
//	try {
//		var progress = new FileProgress(file, this.customSettings.progressTarget);
//		progress.setError();
//		progress.toggleCancel(false);

//		switch (errorCode) {
//		case SWFUpload.UPLOAD_ERROR.HTTP_ERROR:
//			progress.setStatus("Upload Error: " + message);
//			this.debug("Error Code: HTTP Error, File name: " + file.name + ", Message: " + message);
//			break;
//		case SWFUpload.UPLOAD_ERROR.UPLOAD_FAILED:
//			progress.setStatus("Upload Failed.");
//			this.debug("Error Code: Upload Failed, File name: " + file.name + ", File size: " + file.size + ", Message: " + message);
//			break;
//		case SWFUpload.UPLOAD_ERROR.IO_ERROR:
//			progress.setStatus("Server (IO) Error");
//			this.debug("Error Code: IO Error, File name: " + file.name + ", Message: " + message);
//			break;
//		case SWFUpload.UPLOAD_ERROR.SECURITY_ERROR:
//			progress.setStatus("Security Error");
//			this.debug("Error Code: Security Error, File name: " + file.name + ", Message: " + message);
//			break;
//		case SWFUpload.UPLOAD_ERROR.UPLOAD_LIMIT_EXCEEDED:
//			progress.setStatus("Upload limit exceeded.");
//			this.debug("Error Code: Upload Limit Exceeded, File name: " + file.name + ", File size: " + file.size + ", Message: " + message);
//			break;
//		case SWFUpload.UPLOAD_ERROR.FILE_VALIDATION_FAILED:
//			progress.setStatus("Failed Validation.  Upload skipped.");
//			this.debug("Error Code: File Validation Failed, File name: " + file.name + ", File size: " + file.size + ", Message: " + message);
//			break;
//		case SWFUpload.UPLOAD_ERROR.FILE_CANCELLED:
//			// If there aren't any files left (they were all cancelled) disable the cancel button
//			if (this.getStats().files_queued === 0) {
//				document.getElementById(this.customSettings.cancelButtonId).disabled = true;
//			}
//			progress.setStatus("Cancelled");
//			progress.setCancelled();
//			break;
//		case SWFUpload.UPLOAD_ERROR.UPLOAD_STOPPED:
//			progress.setStatus("Stopped");
//			break;
//		default:
//			progress.setStatus("Unhandled Error: " + errorCode);
//			this.debug("Error Code: " + errorCode + ", File name: " + file.name + ", File size: " + file.size + ", Message: " + message);
//			break;
//		}
//	} catch (ex) {
//        this.debug(ex);
//    }
}

function uploadComplete(file) {
//	if (this.getStats().files_queued === 0) {
//		document.getElementById(this.customSettings.cancelButtonId).disabled = true;
//	}
}

// This event comes from the Queue Plugin
function queueComplete(numFilesUploaded) {
//	var status = document.getElementById("divStatus");
//	status.innerHTML = numFilesUploaded + " file" + (numFilesUploaded === 1 ? "" : "s") + " uploaded.";
}