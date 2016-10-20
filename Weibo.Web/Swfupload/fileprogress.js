

var fileprogress = {
    swfObjInstance: null,
    itemTemplate: "<div id=\"{0}\" class=\"item\"><div class=\"desc\"><span class=\"name\">{1}</span> <span class=\"size\">{2}</span> <span class=\"action success\"><a id='cancel' href=\"javascript:void(0)\">È¡Ïû</a></span></div><div class=\"progress\"><div style=\"width: 0%;\" class=\"progressing\"></div><span class=\"percent\">0%</span></div></div>",
    addUploadItem: function (file, targetID) {
        var itemTemplate = fileprogress.itemTemplate.replace("{0}", "swfobject_" + file.id).replace("{1}", file.name).replace("{2}", fileprogress.formatBytes(file.size));
        $("#" + targetID).html(itemTemplate);
    },
    setUploadPercent: function (file, uploadPercent) {
        $("#" + "swfobject_" + file.id).find(".percent").html(uploadPercent + "%");
        $("#" + "swfobject_" + file.id).find(".progressing").css("width", uploadPercent + "%");
    },
    bindCancelUpload: function (file, swfInstance) {
        if (swfInstance) {
            fileprogress.swfObjInstance = swfInstance;
            $("#" + "swfobject_" + file.id).find("#cancel").click(function () {
                fileprogress.swfObjInstance.cancelUpload(file.id);
                $("#" + "swfobject_" + file.id).remove();
            });
        }
    },
    
    setUploadStatus: function (file, errorTxt) {
        $("#" + "swfobject_" + file.id).find(".percent").html(errorTxt);
        $("#" + "swfobject_" + file.id).find(".progressing").css("width", "0%");
    },
    formatUnits: function (baseNumber, unitDivisors, unitLabels, singleFractional) {
        var i, unit, unitDivisor, unitLabel;

        if (baseNumber === 0) {
            return "0 " + unitLabels[unitLabels.length - 1];
        }

        if (singleFractional) {
            unit = baseNumber;
            unitLabel = unitLabels.length >= unitDivisors.length ? unitLabels[unitDivisors.length - 1] : "";
            for (i = 0; i < unitDivisors.length; i++) {
                if (baseNumber >= unitDivisors[i]) {
                    unit = (baseNumber / unitDivisors[i]).toFixed(2);
                    unitLabel = unitLabels.length >= i ? " " + unitLabels[i] : "";
                    break;
                }
            }

            return unit + unitLabel;
        } else {
            var formattedStrings = [];
            var remainder = baseNumber;

            for (i = 0; i < unitDivisors.length; i++) {
                unitDivisor = unitDivisors[i];
                unitLabel = unitLabels.length > i ? " " + unitLabels[i] : "";

                unit = remainder / unitDivisor;
                if (i < unitDivisors.length - 1) {
                    unit = Math.floor(unit);
                } else {
                    unit = unit.toFixed(2);
                }
                if (unit > 0) {
                    remainder = remainder % unitDivisor;

                    formattedStrings.push(unit + unitLabel);
                }
            }

            return formattedStrings.join(" ");
        }
    },

    formatBytes: function (baseNumber) {
        var sizeUnits = [1073741824, 1048576, 1024, 1], sizeUnitLabels = ["GB", "MB", "KB", "B"];
        return fileprogress.formatUnits(baseNumber, sizeUnits, sizeUnitLabels, true);

    }
};