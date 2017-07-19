package jp.co.isid.ham.production.model;

import java.util.List;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;
import jp.co.isid.ham.model.AbstractServiceResult;

/**
*
* <P>
* 支払先一覧の情報を保持する.
* </P>
* <P>
* <B>修正履歴</B><BR>
* ・新規作成(2013/04/01 新HAMチーム)<BR>
* </P>
* @author
*/
@XmlRootElement(namespace = "http://model.production.ham.isid.co.jp/")
@XmlType(namespace = "http://model.production.ham.isid.co.jp/")
public class FindPayDataResult extends AbstractServiceResult {

    /** 支払先一覧の取得 */
    private List<PayDataVO> _payDataVoList;

    /**
     * 支払先一覧VOリストを取得します
     * @return 支払先一覧VO
     */
    public List<PayDataVO> getPayDataVoList() {
        return _payDataVoList;
    }

    /**
     * 支払先一覧VOリストを設定します
     * @param 支払先一覧VO
     */
    public void setPayDataVoList(List<PayDataVO> payDataVoList) {
        _payDataVoList = payDataVoList;
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
