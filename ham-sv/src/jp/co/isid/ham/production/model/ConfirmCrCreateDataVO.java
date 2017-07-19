package jp.co.isid.ham.production.model;

import java.io.Serializable;
import java.util.Date;
import java.util.List;

import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.ham.common.model.Tbj11CrCreateDataVO;

/**
 * <P>
 * CR制作費　確認／確認取消実行時の登録データ保持クラス
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
public class ConfirmCrCreateDataVO implements Serializable {

    /**
     * serialVersionUID
     */
    private static final long serialVersionUID = 1L;

    /** CR制作費管理の最大タイムスタンプ */
    private Date _maxDateTimeForCrCreateData = null;

    /** 検索条件VO */
    private FindCrCreateDataCondition _findCrCreateDataCondition = null;

    /** 区分(1:確認、2:確認取消) */
    private String _confKbn = "";

    /** CR制作費管理VOリスト */
    private List<Tbj11CrCreateDataVO> _tbj11CrCreateDataVoList = null;

    /**
     * CR制作費管理のタイムスタンプ最大値を取得する
     *
     * @return CR制作費管理のタイムスタンプ最大値
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
     * 区分を取得する
     *
     * @return 区分
     */
    public String getConfKbn() {
        return _confKbn;
    }

    /**
     * 区分を設定する
     *
     * @param confKbn 区分
     */
    public void setConfKbn(String confKbn) {
        this._confKbn = confKbn;
    }

    /**
     * CR制作費管理VOリストを取得する
     *
     * @return CR制作費管理VOリスト
     */
    public List<Tbj11CrCreateDataVO> getTbj11CrCreateDataVoList() {
        return _tbj11CrCreateDataVoList;
    }

    /**
     * CR制作費管理VOリストを設定する
     *
     * @param tbj11CrCreateDataVoListUpd CR制作費管理VOリスト
     */
    public void setTbj11CrCreateDataVoList(List<Tbj11CrCreateDataVO> tbj11CrCreateDataVoList) {
        this._tbj11CrCreateDataVoList = tbj11CrCreateDataVoList;
    }

}
