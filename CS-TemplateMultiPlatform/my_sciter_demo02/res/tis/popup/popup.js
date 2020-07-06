/*
 * @FileName: popup.js
 * @Author: tom
 * @Date: 2020-07-02 09:57:56
 * @Version: 2.0
 * @Description: 用于emoji弹出框
 */ 

$(div#emojiAnchor) << event mousedown
{
    if(!this.state.ownspopup) {
        var anchorPoint = 8;
        var popupPoint = 2;
        this.popup( $(popup#emojiPop), (popupPoint << 16) | anchorPoint);
    }
} 
/**
 * @FuncName: 表情的点击事件
 * @Author: tom
 * @Date: 2020-07-02 17:09:50
 * @Param: key: 表情的名称
 * @Return: 
 * @Description: 
 */
function emojiClick(key) {
    // 若没有聚焦，则聚焦到输入框
    if(!$(richtext#chat_richtext).state.focus) $(richtext#chat_richtext).htmlarea.state.focus = true;
    InsertEmot($(richtext#chat_richtext).htmlarea,key);
    $(#emojiPop).state.popup = false;
}
function init() {
    var arr = ['angry','astonished','balloon','birthday','blush','broken_heart','buttonNose','bye','celebrate','clasphands','cold-sweat','confounded','confused','cry','disappointed_relieved','doubt','etriumph','expressionless','eyes','fearful','fireworks','first','flushed','frowning','ghost','gift','grin','heart-eyes','heart','joy','kissing_heart','laughing','lip','maleficeent','mask','muscle','no_mouth','ohYeah','ok_hand','paray','pensive','persevere','pill','punch','rage','relaxed','relieved','rose','scream','shutUp','sleeping','sleepy','smile','smirk','sob','stuck','sunglasses','sweat','sweat_smile','taxi','thumbsdown','thumbsup','tire','tired_face','unamused','v','wink','worried','yum'];
    var emojiListHmtl = "";
    for(var item in arr) {
        var node = "<img class='emoji_list_emoji_item' src='../../assets/images/emoji/" + item +".png' key='" + item + "' />";
        emojiListHmtl += node;
    }
    $(#emoji_list).append(emojiListHmtl);

    var emojiList = $$(.emoji_list_emoji_item);
    for(var item in emojiList) {
        item.onClick = function() {
            emojiClick(this.attributes["key"])
        }
    }
}
init();
