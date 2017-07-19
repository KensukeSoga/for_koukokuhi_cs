package jp.co.isid.ham.media.model;

import java.util.List;

import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.ham.common.model.Mbj35MediaPatternVO;
import jp.co.isid.ham.model.AbstractServiceResult;
/**
*
* <P>
* パターンの情報を保持する.
* </P>
* <P>
* <B>修正履歴</B><BR>
* ・新規作成(2013/2/12 HLC H.Watabe)<BR>
* </P>
* @author HLC H.Watabe
*/
@XmlRootElement(namespace = "http://model.media.ham.isid.co.jp/")
@XmlType(namespace = "http://model.media.ham.isid.co.jp/")
public class FindMediaPatternResult extends AbstractServiceResult{

    /** 媒体パターン名 */
    private List<Mbj35MediaPatternVO> _mpvo;

    /**
     * 媒体パターン名を取得
     * @return 媒体パターン名
     */
    public List<Mbj35MediaPatternVO> getMbj35MediaPattern() {
        return _mpvo;
    }

    /**
     * 媒体パターン名を設定
     * @param mpvo 媒体パターン名
     */
    public void setMbj35MediaPattern(List<Mbj35MediaPatternVO> mpvo) {
        _mpvo = mpvo;
    }

    /** ListだけではWebサービスに公開されないのでダミープロパティを追加 */
    private String _dummy;

    /**
     * ListだけではWebサービスに公開されないのでダミープロパティを追加を取得します
     * @return String ダミープロパティ
     */
    public String getDummy() {
        return _dummy;
    }

    /**
     * ListだけではWebサービスに公開されないのでダミープロパティを追加を設定します
     * @param dummy ダミープロパティ
     */
    public void setDummy(String dummy) {
        this._dummy = dummy;
    }
}
