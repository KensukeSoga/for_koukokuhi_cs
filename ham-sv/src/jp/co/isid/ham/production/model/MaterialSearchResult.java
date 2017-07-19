package jp.co.isid.ham.production.model;

import java.util.List;

import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.ham.common.model.Mbj37DisplayControlVO;
import jp.co.isid.ham.model.AbstractServiceResult;


@XmlRootElement(namespace = "http://model.production.ham.isid.co.jp/")
@XmlType(namespace = "http://model.production.ham.isid.co.jp/")
public class MaterialSearchResult extends AbstractServiceResult {

    /* =============================================================================================*/
    /** ListだけではWebサービスに公開されないのでダミープロパティを追加 */
    private String _dummy;

    /**
     * ListだけではWebサービスに公開されないのでダミープロパティを取得する.
     * @return String ダミープロパティ
     */
    public String getDummy() {
        return _dummy;
    }

    /**
     * ListだけではWebサービスに公開されないのでダミープロパティを設定する.
     * @param dummy ダミープロパティ
     */
    public void setDummy(String dummy) {
        this._dummy = dummy;
    }
    /* =============================================================================================*/

    /**
     * 素材情報リスト変数
     */
    private List<SozaiKanriDataVO> _sozaiKanriDataList = null;

    /** 画面項目表示列制御マスタ */
    private List<Mbj37DisplayControlVO> _mbj37DisplayControlVoList = null;

    /**
     * 素材情報リストを設定します
     * @param val 素材情報リスト
     */
    public void setSozaiKanriDataList(List<SozaiKanriDataVO> val) {
        _sozaiKanriDataList = val;
    }

    /**
     * 素材情報リストを取得します
     * @return 素材情報リスト
     */
    public List<SozaiKanriDataVO> getSozaiKanriDataList() {
        return _sozaiKanriDataList;
    }

    /**
     * 画面項目表示列制御マスタVOリストを取得する
     * @return 画面項目表示列制御マスタVOリスト
     */
    public List<Mbj37DisplayControlVO> getMbj37DisplayControlVoList() {
        return _mbj37DisplayControlVoList;
    }

    /**
     * 画面項目表示列制御マスタVOリストを設定する
     * @param mbj30InputTntVoList 画面項目表示列制御マスタVOリスト
     */
    public void setMbj37DisplayControlVoList(List<Mbj37DisplayControlVO> mbj37DisplayControlVoList) {
        this._mbj37DisplayControlVoList = mbj37DisplayControlVoList;
    }
}
