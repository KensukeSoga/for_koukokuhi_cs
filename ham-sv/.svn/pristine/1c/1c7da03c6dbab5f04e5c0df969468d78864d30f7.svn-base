package jp.co.isid.ham.media.model;

import java.util.List;

import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.ham.common.model.Mbj37DisplayControlVO;
import jp.co.isid.ham.model.AbstractServiceResult;

/**
*
* <P>
* 受注ファイル出力画面の情報を保持する.
* </P>
* <P>
* <B>修正履歴</B><BR>
* ・新規作成(2013/02/18 HLC H.Watabe)<BR>
* </P>
* @author HLC H.Watabe
*/
@XmlRootElement(namespace = "http://model.media.ham.isid.co.jp/")
@XmlType(namespace = "http://model.media.ham.isid.co.jp/")
public class FindOrderSelectResult extends AbstractServiceResult {

    /** 営業作業台帳VO */
    private List<FindOrderSelectVO> _orderSelvo;


    /** 画面項目表示列制御マスタ */
    private List<Mbj37DisplayControlVO> _dc;

    /**
     * 営業作業台帳を取得
     * @return 営業作業台帳
     */
    public List<FindOrderSelectVO> getOrderSelect() {
        return _orderSelvo;
    }

    /**
     * 営業作業台帳を設定
     * @param daichovo
     */
    public void setOrderSelect(List<FindOrderSelectVO> orderSelvo) {
        this._orderSelvo = orderSelvo;
    }

    /**
     * 画面項目表示列制御マスタを取得する
     *
     * @return 画面項目表示列制御マスタ
     */
    public List<Mbj37DisplayControlVO> getDisplayControl() {
        return _dc;
    }

    /**
     * 画面項目表示列制御マスタを設定する
     *
     * @param dc 画面項目表示列制御マスタ
     */
    public void setDisplayControl(List<Mbj37DisplayControlVO> dc) {
        _dc = dc;
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
