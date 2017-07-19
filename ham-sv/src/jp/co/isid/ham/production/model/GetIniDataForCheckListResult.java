package jp.co.isid.ham.production.model;

import java.util.List;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;
import jp.co.isid.ham.common.model.Mbj12CodeVO;
import jp.co.isid.ham.common.model.RepaVbjaMeu07SikKrSprdVO;
import jp.co.isid.ham.model.AbstractServiceResult;

/**
 * <P>
 * CR制作費　起動時データ取得の結果クラス
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/11/30 新HAMチーム)<BR>
 * </P>
 * @author 新HAMチーム
 */
@XmlRootElement(namespace = "http://model.production.ham.isid.co.jp/")
@XmlType(namespace = "http://model.production.ham.isid.co.jp/")
public class GetIniDataForCheckListResult  extends AbstractServiceResult {

    /* =============================================================================================*/
//    /** ListだけではWebサービスに公開されないのでダミープロパティを追加 */
//    private String _dummy;
//
//    /**
//     * ListだけではWebサービスに公開されないのでダミープロパティを取得します
//     * @return String ダミープロパティ
//     */
//    public String getDummy() {
//        return _dummy;
//    }
//
//	/**
//	 * ListだけではWebサービスに公開されないのでダミープロパティを設定します
//	 * @param dummy ダミープロパティ
//	 */
//	public void setDummy(String dummy) {
//		this._dummy = dummy;
//	}
    /* =============================================================================================*/

    /** コードマスタVOリスト */
    private List<Mbj12CodeVO> _mbj12CodeVoList = null;

    /** 経理組織展開テーブルVOリスト */
    private List<RepaVbjaMeu07SikKrSprdVO> _meu07SikKrSprdVoList = null;

    /** 取引先企業VOリスト */
    private List<CheckListThsDataVO> _checkListThsDataVoList = null;

    /**
     * コードマスタVOリストを取得する
     * @return コードマスタVOリスト
     */
    public List<Mbj12CodeVO> getMbj12CodeVoList() {
        return _mbj12CodeVoList;
    }

    /**
     * コードマスタVOリストを設定する
     * @param mbj12CodeVoList コードマスタVOリスト
     */
    public void setMbj12CodeVoList(List<Mbj12CodeVO> mbj12CodeVoList) {
        this._mbj12CodeVoList = mbj12CodeVoList;
    }

    /**
     * 経理組織展開テーブルVOリストを取得する
     * @return コードマスタVOリスト
     */
    public List<RepaVbjaMeu07SikKrSprdVO> getMeu07SikKrSprdVoList() {
        return _meu07SikKrSprdVoList;
    }

    /**
     * 経理組織展開テーブルVOリストを設定する
     * @param meu07SikKrSprdVoList 経理組織展開テーブルVOリスト
     */
    public void setMeu07SikKrSprdVoList(List<RepaVbjaMeu07SikKrSprdVO> meu07SikKrSprdVoList) {
        this._meu07SikKrSprdVoList = meu07SikKrSprdVoList;
    }

    /**
     * 取引先企業VOリストを取得する
     * @return 取引先企業VOリスト
     */
    public List<CheckListThsDataVO> getCheckListThsDataVoList() {
        return _checkListThsDataVoList;
    }

    /**
     * 取引先企業VOリストを設定する
     * @param checkListThsDataVoList 取引先企業VOリスト
     */
    public void setCheckListThsDataVoList(List<CheckListThsDataVO> checkListThsDataVoList) {
        this._checkListThsDataVoList = checkListThsDataVoList;
    }

}
