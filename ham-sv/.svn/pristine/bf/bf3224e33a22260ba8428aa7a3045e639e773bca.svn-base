package jp.co.isid.ham.production.model;

import java.io.Serializable;
import java.util.Date;
import java.util.List;
import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;
import jp.co.isid.ham.common.model.Tbj10CrCarInfoVO;

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
public class RegisterCrCreateDataVO implements Serializable {

    /**
     * serialVersionUID
     */
    private static final long serialVersionUID = 1L;

    /** CR車種情報の最大タイムスタンプ */
    private Date _maxDateTimeForCrCarInfo = null;

    /** CR制作費管理の最大タイムスタンプ */
    private Date _maxDateTimeForCrCreateData = null;

    /** CR制作費管理の件数 */
    private int _countCrCreateData = -1;

    /** 検索条件VO */
    private FindCrCreateDataCondition _findCrCreateDataCondition = null;

    /** CR車種情報VO（登録）リスト */
    private List<Tbj10CrCarInfoVO> _tbj10CrCarInfoVoListReg = null;

    /** CR車種情報VO（更新）リスト */
    private List<Tbj10CrCarInfoVO> _tbj10CrCarInfoVoListUpd = null;

    /** CR制作費管理VO（登録）リスト */
    private List<Tbj11CrCreateDataForUpdVO> _tbj11CrCreateDataVoListReg = null;

    /** CR制作費管理VO（更新）リスト */
    private List<Tbj11CrCreateDataForUpdVO> _tbj11CrCreateDataVoListUpd = null;

    /** CR制作費管理VO（削除）リスト */
    private List<Tbj11CrCreateDataForUpdVO> _tbj11CrCreateDataVoListDel = null;

    /** CR制作費管理VO（中止）リスト */
    private List<Tbj11CrCreateDataForUpdVO> _tbj11CrCreateDataVoListStp = null;

    /** CR制作費管理VO（ソート順更新用）リスト */
    private List<Tbj11CrCreateDataForUpdVO> _tbj11CrCreateDataVoListSort = null;

    /**
     * CR車種情報のタイムスタンプ最大値を取得する
     *
     * @return CR車種情報のタイムスタンプ最大値
     */
    @XmlElement(required = true, nillable=true)
    public Date getMaxDateTimeForCrCarInfo() {
        return _maxDateTimeForCrCarInfo;
    }

    /**
     * CR車種情報のタイムスタンプ最大値を設定する
     *
     * @param maxDateTimeForCrCarInfo CR制作費管理のタイムスタンプ最大値
     */
    public void setMaxDateTimeForCrCarInfo(Date maxDateTimeForCrCarInfo) {
        this._maxDateTimeForCrCarInfo = maxDateTimeForCrCarInfo;
    }

    /**
     * タイムスタンプ最大値を取得する
     *
     * @return タイムスタンプ最大値
     */
    @XmlElement(required = true, nillable=true)
    public Date getMaxDateTimeForCrCreateData() {
        return _maxDateTimeForCrCreateData;
    }

    /**
     * CR制作費管理のタイムスタンプ最大値を設定する
     *
     * @param maxDateTimeForCrCarInfo CR制作費管理のタイムスタンプ最大値
     */
    public void setMaxDateTimeForCrCreateData(Date maxDateTimeForCrCreateData) {
        this._maxDateTimeForCrCreateData = maxDateTimeForCrCreateData;
    }

    /**
     * CR制作費管理の件数を取得する
     *
     * @return CR制作費管理の件数
     */
    @XmlElement(required = true, nillable=true)
    public int getCountCrCreateData() {
        return _countCrCreateData;
    }

    /**
     * CR制作費管理の件数を設定する
     *
     * @param countCrCreateData CR制作費管理の件数
     */
    public void setCountCrCreateData(int countCrCreateData) {
        this._countCrCreateData = countCrCreateData;
    }

    /**
     * 検索条件を取得する
     *
     * @return 検索条件VO
     */
    public FindCrCreateDataCondition getFindCrCreateDataCondition() {
        return _findCrCreateDataCondition;
    }

    /**
     * 検索条件を設定する
     *
     * @param findCrCreateDataCondition 検索条件VO
     */
    public void setFindCrCreateDataCondition(FindCrCreateDataCondition findCrCreateDataCondition) {
        this._findCrCreateDataCondition = findCrCreateDataCondition;
    }

    /**
     * CR車種情報VOリストを取得する
     *
     * @return CR車種情報VOリスト
     */
    public List<Tbj10CrCarInfoVO> getTbj10CrCarInfoVoListReg() {
        return _tbj10CrCarInfoVoListReg;
    }

    /**
     * CR車種情報VOリストを設定する
     *
     * @param tbj10CrCarInfoVoList CR車種情報VOリスト
     */
    public void setTbj10CrCarInfoVoListReg(List<Tbj10CrCarInfoVO> tbj10CrCarInfoVoListReg) {
        this._tbj10CrCarInfoVoListReg = tbj10CrCarInfoVoListReg;
    }

    /**
     * CR車種情報VOリストを取得する
     *
     * @return CR車種情報VOリスト
     */
    public List<Tbj10CrCarInfoVO> getTbj10CrCarInfoVoListUpd() {
        return _tbj10CrCarInfoVoListUpd;
    }

    /**
     * CR車種情報VOリストを設定する
     *
     * @param tbj10CrCarInfoVoList CR車種情報VOリスト
     */
    public void setTbj10CrCarInfoVoListUpd(List<Tbj10CrCarInfoVO> tbj10CrCarInfoVoListUpd) {
        this._tbj10CrCarInfoVoListUpd = tbj10CrCarInfoVoListUpd;
    }

    /**
     * CR制作費管理VO（登録）リストを取得する
     *
     * @return CR制作費管理VO（登録）リスト
     */
    public List<Tbj11CrCreateDataForUpdVO> getTbj11CrCreateDataVoListReg() {
        return _tbj11CrCreateDataVoListReg;
    }

    /**
     * CR制作費管理VO（登録）リストを設定する
     *
     * @param tbj11CrCreateDataVoListReg CR制作費管理VO（登録）リスト
     */
    public void setTbj11CrCreateDataVoListReg(List<Tbj11CrCreateDataForUpdVO> tbj11CrCreateDataVoListReg) {
        this._tbj11CrCreateDataVoListReg = tbj11CrCreateDataVoListReg;
    }

    /**
     * CR制作費管理VO（更新）リストを取得する
     *
     * @return CR制作費管理VO（更新）リスト
     */
    public List<Tbj11CrCreateDataForUpdVO> getTbj11CrCreateDataVoListUpd() {
        return _tbj11CrCreateDataVoListUpd;
    }

    /**
     * CR制作費管理VO（更新）リストを設定する
     *
     * @param tbj11CrCreateDataVoListUpd CR制作費管理VO（更新）リスト
     */
    public void setTbj11CrCreateDataVoListUpd(List<Tbj11CrCreateDataForUpdVO> tbj11CrCreateDataVoListUpd) {
        this._tbj11CrCreateDataVoListUpd = tbj11CrCreateDataVoListUpd;
    }

    /**
     * CR制作費管理VO（削除）リストを取得する
     *
     * @return CR制作費管理VO（削除）リスト
     */
    public List<Tbj11CrCreateDataForUpdVO> getTbj11CrCreateDataVoListDel() {
        return _tbj11CrCreateDataVoListDel;
    }

    /**
     * CR制作費管理VO（削除）リストを設定する
     *
     * @param tbj11CrCreateDataVoListDel CR制作費管理VO（削除）リスト
     */
    public void setTbj11CrCreateDataVoListDel(List<Tbj11CrCreateDataForUpdVO> tbj11CrCreateDataVoListDel) {
        this._tbj11CrCreateDataVoListDel = tbj11CrCreateDataVoListDel;
    }

    /**
     * CR制作費管理VO（中止）リストを取得する
     *
     * @return CR制作費管理VO（中止）リスト
     */
    public List<Tbj11CrCreateDataForUpdVO> getTbj11CrCreateDataVoListStp() {
        return _tbj11CrCreateDataVoListStp;
    }

    /**
     * CR制作費管理VO（中止）リストを設定する
     *
     * @param tbj11CrCreateDataVoListDel CR制作費管理VO（中止）リスト
     */
    public void setTbj11CrCreateDataVoListStp(List<Tbj11CrCreateDataForUpdVO> tbj11CrCreateDataVoListStp) {
        this._tbj11CrCreateDataVoListStp = tbj11CrCreateDataVoListStp;
    }

    /**
     * CR制作費管理VO（ソート順更新用）リストを取得する
     *
     * @return CR制作費管理VO（ソート順更新用）リスト
     */
    public List<Tbj11CrCreateDataForUpdVO> getTbj11CrCreateDataVoListSort() {
        return _tbj11CrCreateDataVoListSort;
    }

    /**
     * CR制作費管理VO（ソート順更新用）リストを設定する
     *
     * @param tbj11CrCreateDataVoListDel CR制作費管理VO（ソート順更新用）リスト
     */
    public void setTbj11CrCreateDataVoListSort(List<Tbj11CrCreateDataForUpdVO> tbj11CrCreateDataVoListSort) {
        this._tbj11CrCreateDataVoListSort = tbj11CrCreateDataVoListSort;
    }

}
