package jp.co.isid.ham.media.model;

import java.util.List;

import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.ham.model.AbstractServiceResult;

/**
*
* <P>
* 全社マスタからの媒体情報を保持する.
* </P>
* <P>
* <B>修正履歴</B><BR>
* ・新規作成(2013/2/12 HLC H.Watabe)<BR>
* </P>
* @author HLC H.Watabe
*/
@XmlRootElement(namespace = "http://model.media.ham.isid.co.jp/")
@XmlType(namespace = "http://model.media.ham.isid.co.jp/")
public class FindMediaByCommonMasterResult extends AbstractServiceResult {

    /** 媒体リスト */
    private List<FindMediaByCommonMasterVO> _mvo;

    /**
     * 媒体リストを取得する
     * @return 媒体リスト
     */
    public List<FindMediaByCommonMasterVO> getMediaByCommonMasterVO() {
        return _mvo;
    }

    /**
     * 媒体リストを設定する
     * @param mvo
     */
    public void setMediaByCommonMasterVO(List<FindMediaByCommonMasterVO> mvo) {
        _mvo = mvo;
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
