package jp.co.isid.ham.media.model;

import java.util.List;

import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.ham.model.AbstractServiceResult;

/**
*
* <P>
* 請求明細書出力画面情報を保持する.
* </P>
* <P>
* <B>修正履歴</B><BR>
* ・新規作成(2013/03/25 HLC H.Watabe)<BR>
* </P>
* @author HLC H.Watabe
*/
@XmlRootElement(namespace = "http://model.media.ham.isid.co.jp/")
@XmlType(namespace = "http://model.media.ham.isid.co.jp/")
public class FindBillStatementDataResult extends AbstractServiceResult {

    /** 営業作業台帳情報 */
    private List<FindBillStatementDataVO> _daicho;

    /**
     * 営業作業台帳情報を取得します
     * @return _daicho
     */
    public List<FindBillStatementDataVO> getTbj02EigyoDaicho() {
        return _daicho;
    }

    /**
     * 営業作業台帳情報を設定します
     * @param daicho
     */
    public void setTbj02EigyoDaicho(List<FindBillStatementDataVO> daicho) {
        _daicho = daicho;
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
