

$(function () {

    var ajaxFormSubmit = function () {
        var $form = $(this);

        var options = {
            url: $form.attr("action"),
            type: $form.attr("method"),
            data: $form.serialize()
        };

        $.ajax(options).done(function (data) {
            var $target = $($form.attr("data-ssg-target"));
            var $newHtml = $(data);
            $target.replaceWith($newHtml);
            $newHtml.effect("highlight");
        });

        return false;
    };

    var submitAutocompleteForm = function (event, ui) {

        var $input = $(this);
        $input.val(ui.item.label);

        var $form = $input.parents("form:first");
        $form.submit();
    };

    var createAutocomplete = function () {
        var $input = $(this);

        var options = {
            source: $input.attr("data-ssg-autocomplete"),
            select: submitAutocompleteForm
        };

        $input.autocomplete(options);
    };

    var getPage = function () {
        var $a = $(this);

        var options = {
            url: $a.attr("href"),
            data: $("form").serialize(),
            type: "get"
        };
        //alert(options.url);

        //var x = $a.parents("div.pagination-container").attr("data-ssg-target");
        //var x = $a.parents("div.pagination-container").attr("data-ssg-target");
        //alert(x);

        $.ajax(options).done(function (data) {
            var target = $a.parents("div.pagination-container").parents("div").attr("data-ssg-target");
            //alert(target);
            $(target).replaceWith(data);
        });
        return false;

    };

    //alert("aa");

    $("form[data-ssg-ajax='true']").submit(ajaxFormSubmit);
    //$("input[data-ssg-autocomplete]").each(createAutocomplete);
    
    $(".pagination-container a").on("click",  getPage);

    
});