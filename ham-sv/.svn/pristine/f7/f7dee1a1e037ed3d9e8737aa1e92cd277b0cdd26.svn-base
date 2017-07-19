package jp.co.isid.ham.media.model;

import java.util.List;

import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.ham.common.model.Tbj02EigyoDaichoVO;
import jp.co.isid.ham.model.AbstractServiceResult;

/**
*
* <P>
* 営業作業台帳の情報を保持する.
* </P>
* <P>
* <B>修正履歴</B><BR>
* ・新規作成(2013/02/06 HLC H.Watabe)<BR>
* </P>
* @author HLC H.Watabe
*/
@XmlRootElement(namespace = "http://model.media.ham.isid.co.jp/")
@XmlType(namespace = "http://model.media.ham.isid.co.jp/")
public class FindGrossSumResult extends AbstractServiceResult{

    /**
     * 営業作業台帳VO
     */
    private List<Tbj02EigyoDaichoVO> _edvo;

    /**
     * グロス金額合計を取得する
     * @return グロス金額合計
     */
    public List<Tbj02EigyoDaichoVO> getGrossSum() {
        return this._edvo;
    }

    /**
     * グロス金額合計をセットする
     * @param edvo グロス金額合計
     */
    public void setGrossSum(List<Tbj02EigyoDaichoVO> edvo) {
        this._edvo = edvo;
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
