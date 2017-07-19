package jp.co.isid.ham.production.model;

import java.io.Serializable;
import java.util.List;

import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.ham.common.model.Mbj46ThsVO;

/**
 * <P>
 * CR制作費　登録実行時の登録データ保持クラス
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/12/05 新HAMチーム)<BR>
 * </P>
 *
 * @author 新HAMチーム
 */
@XmlRootElement(namespace = "http://model.production.ham.isid.co.jp/")
@XmlType(namespace = "http://model.production.ham.isid.co.jp/")
public class RegisterThsVO implements Serializable {

    /**
     * serialVersionUID
     */
    private static final long serialVersionUID = 1L;

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

    /** 取引先マスタVOリスト */
    private List<Mbj46ThsVO> _mbj46ThsVoList = null;

    /**
     * 取引先VOリストを取得する
     *
     * @return 取引先VOリスト
     */
    public List<Mbj46ThsVO> getMbj46ThsVoList() {
        return _mbj46ThsVoList;
    }

    /**
     * 取引先リストを設定する
     *
     * @param mbj46ThsVoList 取引先VOリスト
     */
    public void setMbj46ThsVoList(List<Mbj46ThsVO> mbj46ThsVoList) {
        this._mbj46ThsVoList = mbj46ThsVoList;
    }

}
