package jp.co.isid.ham.media.model;

import java.util.List;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;
import jp.co.isid.ham.model.AbstractServiceResult;


/**
*
* <P>
* 入力拒否データの情報を保持する.
* </P>
* <P>
* <B>修正履歴</B><BR>
* ・新規作成(2012/12/18 FM H.izawa)<BR>
* </P>
* @author FM H.Izawa
*/
@XmlRootElement(namespace = "http://model.media.ham.isid.co.jp/")
@XmlType(namespace = "http://model.media.ham.isid.co.jp/")
public class FindInputRejectionResult extends AbstractServiceResult {

    /** 入力拒否データの取得by媒体状況管理 */
    private List<FindInputRejectionVO> _rep;

    /** 入力拒否データの取得 by 営業作業台帳*/
    private List<FindInputRejectionVO> _rep1;
    /**
     * 入力拒否VOリストを取得します
     * @return _cam
     */
    public List<FindInputRejectionVO> getInputReject() {
        return _rep;
    }

    /**
     * 入力拒否VOリストを設定します
     * @param _cam セットする _cam
     */
    public void setInputReject(List<FindInputRejectionVO> rep) {
        _rep = rep;
    }

    /**
     * 入力拒否VOリストを取得します
     * @return _cam
     */
    public List<FindInputRejectionVO> getInputRejectByEigyo() {
        return _rep1;
    }

    /**
     * 入力拒否VOリストを設定します
     * @param _cam セットする _cam
     */
    public void setInputRejectByEigyo(List<FindInputRejectionVO> rep1) {
        _rep1 = rep1;
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
