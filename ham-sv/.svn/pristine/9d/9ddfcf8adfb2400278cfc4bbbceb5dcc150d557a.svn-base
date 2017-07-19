package jp.co.isid.ham.production.model;

import java.util.List;

import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.ham.common.model.RepaVbjaMeu07SikKrSprdVO;
import jp.co.isid.ham.common.model.RepaVbjaMeu29CcVO;
import jp.co.isid.ham.common.model.RepaVbjaMeu2FHmokVO;
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
public class GetRepDataForChkListResult  extends AbstractServiceResult {

    /* =============================================================================================*/
    /** ListだけではWebサービスに公開されないのでダミープロパティを追加 */
    private String _dummy;

    /**
     * ListだけではWebサービスに公開されないのでダミープロパティを取得します
     * @return String ダミープロパティ
     */
    public String getDummy() {
        return _dummy;
    }

    /**
     * ListだけではWebサービスに公開されないのでダミープロパティを設定します
     * @param dummy ダミープロパティ
     */
    public void setDummy(String dummy) {
        this._dummy = dummy;
    }
    /* =============================================================================================*/

    /** R3側のデータリスト */
    private List<RepDataForChkListR3VO> _repDataForChkListR3 = null;
    /** HAM側のデータリスト */
    private List<RepDataForChkListHAMVO> _repDataForChkListHAM = null;
    /** 費目マスタのデータリスト */
    private List<RepaVbjaMeu07SikKrSprdVO> _repaVbjaMeu07SikKrSprd = null;
    /** 経理組織展開テーブルのデータリスト */
    private List<RepaVbjaMeu2FHmokVO> _repaVbjaMeu2FHmok = null;
//    /** 個人情報VIEWデータリスト */
//    private List<Vbj01AccUserVO> _vbj01AccUser = null;
    /** 税区分／名称のデータリスト */
    private List<RepaVbjaMeu29CcVO> _repaVbjaMeu29Cc = null;


    /**
     * R3側のヘッダ用データリストを取得します
     * @return
     */
    public List<RepDataForChkListR3VO> getRepDataForChkListR3() {
        return _repDataForChkListR3;
    }

    /**
     * R3側のヘッダ用データリストを設定します
     * @param repDataForCostMngHeader
     */
    public void setRepDataForChkListR3(List<RepDataForChkListR3VO> repDataForChkListR3) {
        _repDataForChkListR3 = repDataForChkListR3;
    }

    /**
     * HAM側の明細用データリストを取得します
     * @return
     */
    public List<RepDataForChkListHAMVO> getRepDataForChkListHAM() {
        return _repDataForChkListHAM;
    }

    /**
     * HAM側の明細用データリストを設定します
     * @param repDataForCostMngDetails
     */
    public void setRepDataForChkListHAM(List<RepDataForChkListHAMVO> repDataForChkListHAM) {
        _repDataForChkListHAM = repDataForChkListHAM;
    }

    /**
     * 費目マスタデータリストを取得します
     * @return
     */
    public List<RepaVbjaMeu07SikKrSprdVO> getRepaVbjaMeu07SikKrSprd() {
        return _repaVbjaMeu07SikKrSprd;
    }

    /**
     * 費目マスタデータリストを設定します
     * @param repaVbjaMeu07SikKrSprd
     */
    public void setRepaVbjaMeu07SikKrSprd(List<RepaVbjaMeu07SikKrSprdVO> repaVbjaMeu07SikKrSprd) {
        _repaVbjaMeu07SikKrSprd = repaVbjaMeu07SikKrSprd;
    }

    /**
     * 経理組織展開テーブルデータリストを取得します
     * @return
     */
    public List<RepaVbjaMeu2FHmokVO> getRepaVbjaMeu2FHmok() {
        return _repaVbjaMeu2FHmok;
    }

    /**
     * 経理組織展開テーブルリストを設定します
     * @param repaVbjaMeu2FHmok
     */
    public void setRepaVbjaMeu2FHmok(List<RepaVbjaMeu2FHmokVO> repaVbjaMeu2FHmok) {
        _repaVbjaMeu2FHmok = repaVbjaMeu2FHmok;
    }

//    /**
//     * 個人情報VIEWテーブルデータリストを取得します
//     * @return
//     */
//    public List<Vbj01AccUserVO> getVbj01AccUser() {
//        return _vbj01AccUser;
//    }
//
//    /**
//     * 個人情報VIEWテーブルリストを設定します
//     * @param vbj01AccUser
//     */
//    public void setVbj01AccUser(List<Vbj01AccUserVO> vbj01AccUser) {
//        _vbj01AccUser = vbj01AccUser;
//    }

    /**
     * 税区分／名称データリストを取得します
     * @return
     */
    public List<RepaVbjaMeu29CcVO> getRepaVbjaMeu29Cc() {
        return _repaVbjaMeu29Cc;
    }

    /**
     * 税区分／名称リストを設定します
     * @param repaVbjaMeu29Cc
     */
    public void setRepaVbjaMeu29Cc(List<RepaVbjaMeu29CcVO> repaVbjaMeu29Cc) {
        _repaVbjaMeu29Cc = repaVbjaMeu29Cc;
    }

}
