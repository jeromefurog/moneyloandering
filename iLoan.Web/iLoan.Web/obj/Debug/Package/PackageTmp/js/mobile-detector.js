/*!
    Add mobiledevice class to element you want to hide 
*/

jQuery(document).ready(function ($) {
    var deviceAgent = navigator.userAgent.toLowerCase();
    var agentID = deviceAgent.match(/(iphone|ipod|ipad|android|blackberry|webos|windows phone)/);
    if (agentID) {
        $('.desktop').hide();
    } else {
        $('.desktop').show();
    }
});

