package jp.co.isid.ham.media.model;

import java.util.List;

import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.ham.common.model.Mbj37DisplayControlVO;
import jp.co.isid.ham.model.AbstractServiceResult;

/**
* <P>
* Excel取込みエラー画面の情報を保持する.
* </P>
* <P>
* <B>修正履歴</B><BR>
* ・新規作成(2013/01/28 HLC H.Watabe)<BR>
* </P>
* @author HLC H.Watabe
*/
@XmlRootElement(namespace = "http://model.media.ham.isid.co.jp/")
@XmlType(namespace = "http://model.media.ham.isid.co.jp/")
public class FindExcelInputErrorResult extends AbstractServiceResult {

    /** 画面表示列設定の取得 */
    private List<Mbj37DisplayControlVO> _disp;

    /**
     * 画面表示列情報を取得します
     * @return _disp
     */
    public List<Mbj37DisplayControlVO> getMbj37DisplayControl() {
        return _disp;
    }

    /**
     * 画面表示列情報を設定します
     * @param disp
     */
    public void setMbj37DisplayControl(List<Mbj37DisplayControlVO> disp) {
        _disp = disp;
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
