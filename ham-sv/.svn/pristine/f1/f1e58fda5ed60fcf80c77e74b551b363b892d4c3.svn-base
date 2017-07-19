package jp.co.isid.ham.media.model;

import java.util.List;

import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.ham.common.model.Tbj20SozaiKanriListVO;
import jp.co.isid.ham.model.AbstractServiceResult;

/**
*
* <P>
* 素材の情報を保持する.
* </P>
* <P>
* <B>修正履歴</B><BR>
* ・新規作成(2013/02/05 HLC H.Watabe)<BR>
* </P>
* @author HLC H.Watabe
*/
@XmlRootElement(namespace = "http://model.media.ham.isid.co.jp/")
@XmlType(namespace = "http://model.media.ham.isid.co.jp/")
public class FindSozaiDataByRCodeResult extends AbstractServiceResult {

    /** 素材管理のデータを保持する */
    private List<Tbj20SozaiKanriListVO> _sozaivo;

    /**
     * 素材管理のデータを取得する
     * @return 素材管理データ
     */
    public List<Tbj20SozaiKanriListVO> getSozaiKanriList() {
        return this._sozaivo;
    }

    /**
     * 素材管理のデータをセットする
     * @param sozaivo
     */
    public void setSozaiKanriList(List<Tbj20SozaiKanriListVO> sozaivo) {
        this._sozaivo = sozaivo;
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
