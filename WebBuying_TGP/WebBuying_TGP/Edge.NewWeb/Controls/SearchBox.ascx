<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SearchBox.ascx.cs" Inherits="Edge.Web.Controls.SearchBox" %>
<table width="100%" border="0" cellspacing="0" cellpadding="0" class="<%=this.getGuid%>">
    <tr>
        <td align="center">
            <div class="divSearch">
                <table border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td>
                            <table border="0" cellspacing="0" cellpadding="0">
                                <tr class="items">
                                    <td align="center" style="padding-top: 3px; padding-bottom: 3px">
                              <%--          <select name="leftBracket">
                                            <option value="-1"></option>
                                            <%=Edge.Web.Tools.SearchBox.PublicMethod.GetEnumType(typeof(Edge.Web.Tools.SearchBox.CommonState.LeftBracket))%>
                                        </select>--%>
                                        <select name="selSearchType">
                                            <%=this.selOptions%>
                                        </select>
                                        <select name="symbol">
                                            <%=Edge.Web.Tools.SearchBox.PublicMethod.GetEnumType(typeof(Edge.Web.Tools.SearchBox.CommonState.Symbol))%>
                                        </select>
                                        <input type="text" name="txtSearchValue" style="width: 120px;" />
              <%--                          <select name="rightBracket">
                                            <option value="-1"></option>
                                            <%=Edge.Web.Tools.SearchBox.PublicMethod.GetEnumType(typeof(Edge.Web.Tools.SearchBox.CommonState.RightBracket))%>
                                        </select>--%>
                                        <select name="logic">
                                            <%=Edge.Web.Tools.SearchBox.PublicMethod.GetEnumType(typeof(Edge.Web.Tools.SearchBox.CommonState.logic))%>
                                        </select>
                                    </td>
                                    <td align="left">
                                        <a href="###" class="addBtn" title="增加搜索条件">
                                            <img src="<%= ResolveUrl("~/Images/add_search.gif") %>" border="0" /></a> <a href="###" class="delBtn"
                                                title="删除搜索条件">
                                                <img src="<%= ResolveUrl("~/Images/del_search.gif") %>" border="0" /></a>
                                    </td>
                                </tr>
                                <tr class="temp">
                                    <td align="center" style="padding-top: 3px; padding-bottom: 3px">
                 <%--                       <select name="leftBracket">
                                            <option value="-1"></option>
                                            <%=Edge.Web.Tools.SearchBox.PublicMethod.GetEnumType(typeof(Edge.Web.Tools.SearchBox.CommonState.LeftBracket))%>
                                        </select>--%>
                                        <select name="selSearchType">
                                            <%=this.selOptions%>
                                        </select>
                                        <select name="symbol">
                                            <%=Edge.Web.Tools.SearchBox.PublicMethod.GetEnumType(typeof(Edge.Web.Tools.SearchBox.CommonState.Symbol))%>
                                        </select>
                                        <input type="text" name="txtSearchValue" style="width: 120px;" />
                <%--                        <select name="rightBracket">
                                            <option value="-1"></option>
                                            <%=Edge.Web.Tools.SearchBox.PublicMethod.GetEnumType(typeof(Edge.Web.Tools.SearchBox.CommonState.RightBracket))%>
                                        </select>--%>
                                        <select name="logic">
                                            <%=Edge.Web.Tools.SearchBox.PublicMethod.GetEnumType(typeof(Edge.Web.Tools.SearchBox.CommonState.logic))%>
                                        </select>
                                    </td>
                                    <td align="left">
                                        <a href="###" class="addBtn" title="增加搜索条件">
                                            <img src="<%= ResolveUrl("~/Images/add_search.gif") %>" border="0" /></a> <a href="###" class="delBtn"
                                                title="删除搜索条件">
                                                <img src="<%= ResolveUrl("~/Images/del_search.gif") %>" border="0" /></a>
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td align="left" style="padding-left: 10px;">
                            <a href="###" class="btnSearch">
                                <img src="<%= ResolveUrl("~/Images/search.png") %>" border="0" /></a>
                            <asp:Literal runat="server" ID="lbMsg"></asp:Literal>
                        </td>
                    </tr>
                </table>
            </div>
        </td>
    </tr>
</table>

<script type="text/javascript">
    $(function () {
        <%=this.getGuid%>.Init();
    });
    var <%=this.getGuid%>={
        //字段Change事件
        FieldChange:function(obj){
                        
                        var typeValue = $.trim($(obj).find("option:selected").attr("type")); //字段的类型
                        var inputType=$.trim($(obj).find("option:selected").attr("inputType")); //要输入的控件类型（select 、input。。。）

                        $txtInput = $(obj).closest("tr").find("[name='txtSearchValue']");//手动输入区（更新控件类型前）

                        //设置手动输入区的控件类型
                        switch(inputType)
                        {
                            case "text":
                            $txtInput.after("<input type=\"text\" name=\"txtSearchValue\" style=\"width:120px;\"/>");
                            $txtInput.remove();
                            break;
                            case "select":
                            $txtInput.after("<select name=\"txtSearchValue\" style=\"width:120px;\"/></select>");
                            $txtInput.remove();
                            break;
                        }
                        $txtInput = $(obj).closest("tr").find("[name='txtSearchValue']");//手动输入区（更新控件类型后）
                        
                        switch (typeValue) {
                            case "dateTime":
                              $txtInput.css({"width":"104px"}).attr({"readonly":"readonly"});
                              $txtInput.datepicker({
                                  changeMonth: true,
                                  changeYear: true,
                                  dateFormat: 'yy-mm-dd'
                              }
                              );
                               // $txtInput.datepicker({
                               //     showOn: "button",
                               //     buttonImage: "../Images/selicon.gif",
			                   //     buttonImageOnly: true
                              //  });
                             //   $imgs=$txtInput.closest("tr").find("img.ui-datepicker-trigger");
                             //   $($imgs[0]).show();
                              //  $imgs.not($imgs[0]).remove();
                                break;
                            default:
                                $txtInput.removeAttr("readonly").css({"width":"120px"}).unbind("keydown").unbind("keypress").unbind("keyup");//解除datePicker对文本不能输入非时间字符的限制
                                $txtInput.closest("tr").find("img.ui-datepicker-trigger").hide();
                                break;
                        }        
        },
        Init:function(){
                $con = $("table.<%=this.getGuid%>");
//                $searchCon = $con.find(".divSearch");
//                $imgSwitch = $con.find(".openImg");
//                $searchCon.hide();
//                $imgSwitch.live("click", function () {
//                    $searchCon.slideToggle("fast", function () {
//                        if ($(this).css("display") == "none") {
//                            $imgSwitch.find("img").attr({ "src": "/Images/down.gif","alt":"展开搜索" });
//                        }
//                        else {
//                            $imgSwitch.find("img").attr({ "src": "/Images/up.gif","alt":"隐藏搜索" });
//                        }
//                    });
//                });
                //动态增删行
                $.DynamicCon({ container: ".<%=this.getGuid%>", items: ".items", maxCount: 20 });
                //通用搜索中字段下拉框
                $fieldSel =$con.find("select[name='selSearchType']"); //要搜索的字段下拉框

                $fieldSel.live("change", function () {
                    <%=this.getGuid%>.FieldChange(this);
                });

                //搜索：绑定提交事件
                $con.find(".btnSearch").live("click",function(){
                    //1：拼接所有搜索框中的条件为URL
                    var param=[];
                    var leftBracket,selectValue,selectDataType,symbol,inputValue,rightBracket,logic;//左括号、字段、字段数据类型、运算符、输入区、右括号、逻辑符
                    $con.find("tr.items").each(function(){
                        $selectField=$(this).find("select[name='selSearchType']");//当前的下拉字段

                        inputValue=escape($.trim($(this).find("[name='txtSearchValue']").val()));//输入区

                        selectDataType=$selectField.find("option:selected").attr("type");//字段数据类型
                        selectValue=$selectField.val();//当前下拉字段的值（字段）
                        if(selectValue==""||selectValue=="-1"||inputValue=="")
                        {
                            return true;
                        }
                        
                        leftBracket=$(this).find("[name='leftBracket']").val();//左括号
                        symbol=$(this).find("[name='symbol']").val();//运算符
                        
                        rightBracket=$(this).find("[name='rightBracket']").val();//右括号
                        logic=$(this).find("[name='logic']").val();//逻辑符
                        
                        param.push(leftBracket+"|"+selectValue+"|"+selectDataType+"|"+symbol+"|"+escape(inputValue.replace(/[|]/,'').replace(/[,]/g,''))+"|"+rightBracket+"|"+logic);
                    });
                    
                    //2：跳转页面进行查询
                    var ps= CommonJs.GetUrlParams();//json
                    ps["where"]=param;
                    var page=ps["page"];
                    if(page!=undefined&&page!=null&&page!="")
                    {
                        ps["page"]="1";//将当前页码设置为1（第一页）
                    }
                    var url=location.href.replace(/[#]/g,'');
                    if(location.href.indexOf('?')>-1)
                    {
                        url=location.href.substring(0,location.href.indexOf('?'));
                    }
                    location.href=url+"?"+CommonJs.GetUrlByJson(ps);
                });

                //页面加载时对搜索框的初始化
                var currentUrl= CommonJs.GetUrlParams();//json
                if(currentUrl["where"]!=undefined&&currentUrl["where"]!="")
                {
                        $con.find(".openImg").click();
                        var strWhere=unescape(currentUrl["where"]);
                        var wp=strWhere.split(',');
                        if(wp.length>1)//刚开始本来有一行
                        {
                            for(var m=0;m<wp.length-1;m++)
                            {
                                $con.find(".addBtn:eq(0)").click();
                            }
                        }
                        
                        //给搜索框赋默认值
                        $trs=$con.find("tr.items");
                        if(wp.length==$trs.length)
                        {
                            var values=[];
                            $trs.each(function(i){
                                $leftBracketObj=$(this).find("[name='leftBracket']");//左括号
                                $fieldObj=$(this).find("[name='selSearchType']");//字段
                                //where中有个字段类型（在字段对象的option中的type属性中）
                                $symbolObj=$(this).find("[name='symbol']");//运算符
                                $inputValueObj=$(this).find("[name='txtSearchValue']");//输入区(旧)
                                $rightBracketObj=$(this).find("[name='rightBracket']");//右括号
                                $logicObj=$(this).find("[name='logic']");//逻辑符
                                
                                values=wp[i].split('|');//具体值
                                if(values.length==7)//上面共有6个设置区(左括号、字段...)
                                {
                                    CommonJs.SelectedObj($leftBracketObj[0],values[0]);
                                    CommonJs.SelectedObj($fieldObj[0],values[1]);
                                    <%=this.getGuid%>.FieldChange($fieldObj[0]);//调用字段下拉事件

                                    /***********重要******在使用此控件的页面必须存在funs.fieldChangeEvent事件******/
                                    funs.fieldChangeEvent($fieldObj[0]);//生成select的options
                                    
                                    
                                    //values[2]为字段类型
                                    CommonJs.SelectedObj($symbolObj[0],values[3]);

                                    $inputValueObj=$(this).find("[name='txtSearchValue']");//输入区(新)上面调用了FieldChange事件后，此对象又重新生成了。
                                    switch($fieldObj.find("option:selected").attr("inputType"))
                                    {
                                        case "text":
                                        $inputValueObj.val(unescape(unescape(values[4])));
                                        break;
                                        case "select":
                                        CommonJs.SelectedObj($inputValueObj[0],unescape(unescape(values[4])));
                                        break;
                                    }
                                    

                                    CommonJs.SelectedObj($rightBracketObj[0],values[5]);
                                    CommonJs.SelectedObj($logicObj[0],values[6]);
                                }
                            });
                        }
                }

        }
    }
</script>

