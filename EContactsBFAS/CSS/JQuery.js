
$(document).ready(function(){
// code kiem tra dulieu tren trang nhap TTSV
$("#ckTen,#ckNgaySinh,#ckGioi,#ckQQ").hide();
$("#ctl00_ContentPlaceHolder1_btnThem").click(function()
    {
    $("#ckTen,#ckNgaySinh,#ckGioi,#ckQQ").hide();
    if($("#ctl00_ContentPlaceHolder1_txtHoTen").val()=="")
    {
        $("#ckTen").css('color','red').show();
    }
    else {$("#ckTen").hide();}
    if($("#ctl00_ContentPlaceHolder1_cboNgay_TextBox").val()=="Ngày")
    {
        $("#ckNgaySinh").css("color","red").show();
    }
    else {}
//    if(($("#cboNgay").val()=="Ngày" )&& ($("#cboThang").val()=="Tháng")&& ($("#cboNam").val()=="Năm"))
//    {
//        $("#ckNgaySinh").css("color","red").show();
//    }
//    else {$("#ckNgaySinh").hide();}
//    if($("cboNam").val()=="Năm")
//    {
//        $("#ckNgaySinh").css("color","red").show();
//    }
    if($("#ctl00_ContentPlaceHolder1_txtQueQuan").val()=="")
    {
        $("#ckQQ").css("color","red").show();
    }
    else {$("#ckQQ").hide();}
    
    });

});

$(document).ready(function(){
   $ ('.slideshow img:gt(0)').hide();
        setInterval(function(){
     $ ('.slideshow :first-child').fadeOut()
             .next('img').fadeIn()
         .end().appendTo('.slideshow');}, 
          5000);
          })
//    var id="SlideJquery";
//    var arr=$('#'+id+' img');
//    var current=$('#'+id+' img:first-child');
//    var i=0;
//    var duration=4000;
//    $('#'+id+' img').hide();
//    //hàm slideshow
//    function SlideShow(current)
//    {
//        current.fadeIn(duration,function(){
//            $(this).fadeOut(duration,function(){
//                ++i;
//                if(i==arr.length)
//                {
//                    i=0;
//                    current=$('#'+id+' img:first-child');
//                    SlideShow(current);
//                }
//                else
//                {
//                    SlideShow(current.next());
//                }
//            });
//        });
          
     
   function edit_confirm()
     { 
    var result = confirm("Bạn có thực sự muốn thanh toán không?");    
    if(result)
    {
        return true;
    }    
    return false;
    } 