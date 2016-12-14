﻿define(['knockout', 'postbox', 'config', 'toastr','dataservice'], function (ko, postbox, config, toastr, dataservice) {
    return function (params) {
        var annotation = ko.observable(params.annotation);
        var annotationsR = ko.observableArray(params.annotations);
        console.log(params.annotations);
        console.log(params.annotation);
        console.log(JSON.stringify(ko.toJS(annotation)));
        var saveAnnotation = function () {
            postbox.publish(config.events.saveAnnotation, ko.toJS(annotation));
            toastr.success("Annotation saved!");
           var annoPut = ko.toJS(annotation);
           dataservice.putAnno(annoPut,annoPut.annotationId,function(result) {
                   console.log(result);
            });
           };
        var deleteAnnotation = function () {
            postbox.publish(config.events.deleteAnnotation);
            console.log(ko.toJS(annotationsR));
            var annoDel = ko.toJS(annotation);
            toastr.success("Annotation deleted!");
            dataservice.delAnno(annoDel.annotationId, function (result) {
                console.log(result);
                
            });
           
        };
        
        
        postbox.subscribe(config.events.selectAnnotation, function (p) {
            annotation(p);
        });
        return {
            annotation,
            saveAnnotation,
            deleteAnnotation
        };
    };
});
