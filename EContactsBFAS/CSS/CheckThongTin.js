 function kiemtrakhongdetrong()
    {
    //tên không được trống
    var check=true;
     var txtSmallCatalogueNameR=document.getElementById('<%=txtSmallCatalogueName.ClientID%>');
     var lblSmallCatalogueNameR=document.getElementById('<%=lblSmallCatalogueName.ClientID%>');
     if(txtSmallCatalogueNameR.value=="")
     {
     lblSmallCatalogueNameR.innerHTML="Tên mục tin không được để trống!";
     check=false;
     }
     return check;
    } 