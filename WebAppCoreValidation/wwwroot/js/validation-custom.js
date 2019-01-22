(function ($) {
    $.validator.addMethod('data-val-more-than',
        function (value, element, params) {                        
            var nameCompare = $(element).attr('data-val-more-than-field');
            if (nameCompare) {
                var valueCompare = $("#" + nameCompare).val();
                var valueInitials = parseInt(valueCompare);
                var valueEnds = parseInt(value);
                if (valueInitials && valueEnds && (valueInitials <= valueEnds)) {
                    return true;
                }
            }
            return false;
        }, function (params, element) {            
            var msgCompare = $(element).attr('data-val-more-than');
            if (!msgCompare) {
                msgCompare = 'ValueEnds less than ValueInitials';
            }
            return msgCompare;
        });
    $.validator.unobtrusive.adapters.addBool('data-val-more-than');
})(jQuery);