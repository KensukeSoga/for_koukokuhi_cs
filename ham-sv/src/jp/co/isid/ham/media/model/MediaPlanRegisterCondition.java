package jp.co.isid.ham.media.model;

import java.io.Serializable;

import jp.co.isid.ham.common.model.Tbj01MediaPlanVO;
import jp.co.isid.ham.common.model.Tbj13CampDetailVO;

import java.util.Date;
import java.util.List;

import javax.xml.bind.annotation.XmlElement;

public class MediaPlanRegisterCondition implements Serializable {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /**媒体状況管理登録用VO */
    private List<Tbj01MediaPlanVO> _insVo;
    /**媒体状況管理更新用VO */
    private List<Tbj01MediaPlanVO> _delVo;
    /**媒体状況管理削除用VO */
    private List<Tbj01MediaPlanVO> _updVo;
    /**キャンペーン詳細登録用VO */
    private List<Tbj13CampDetailVO> _deInsVo;
    /**キャンペーン詳細削除用VO */
    private List<Tbj13CampDetailVO> _deDelVo;
    /**キャンペーン詳細更新用VO */
    private List<Tbj13CampDetailVO> _deUpdVo;

    /**媒体再作成後の登録かのフラグ(true:媒体未作成後:false:媒体再作成後)*/
    private boolean _insOnlyFlg;

    /**HamID*/
    private String _hamId;

    /**ユーザ名*/
    private String _hamNm;

    /**更新プログラム*/
    private String _updApl;

    /** ダミープロパティ */
    private String _dummy;

    /**データカウント*/
    private int _dataCount;

    /**最終更新者ID*/
    private String _latestupdId;

    /**最終更新日時*/
    private Date _latestDate;

    /**
     * @return insVo
     */
    public List<Tbj01MediaPlanVO> getInsVo() {
        return _insVo;
    }
    /**
     * @param insVo セットする insVo
     */
    public void setInsVo(List<Tbj01MediaPlanVO> insVo) {
        this._insVo = insVo;
    }

    /**
     * @return _delVo
     */
    public List<Tbj01MediaPlanVO> getDelVo() {
        return _delVo;
    }
    /**
     * @param _delVo セットする _delVo
     */
    public void setDelVo(List<Tbj01MediaPlanVO> delVo) {
        this._delVo = delVo;
    }

    /**
     * @return updVo
     */
    public List<Tbj01MediaPlanVO> getUpdVo() {
        return _updVo;
    }
    /**
     * @param updVo セットする updVo
     */
    public void setUpdVo(List<Tbj01MediaPlanVO> updVo) {
        this._updVo = updVo;
    }

    /**
     * @return deInsVo
     */
    public List<Tbj13CampDetailVO> getDeInsVo() {
        return _deInsVo;
    }
    /**
     * @param deInsVo セットする deInsVo
     */
    public void setDeInsVo(List<Tbj13CampDetailVO> deInsVo) {
        this._deInsVo = deInsVo;
    }


    /**
     * @return deDelVo
     */
    public List<Tbj13CampDetailVO> getDeDelVo() {
        return _deDelVo;
    }
    /**
     * @param deDelVo セットする deDelVo
     */
    public void setDeDelVo(List<Tbj13CampDetailVO> deDelVo) {
        this._deDelVo = deDelVo;
    }

    /**
     * @return deUpdVo
     */
    public List<Tbj13CampDetailVO> getDeUpdVo() {
        return _deUpdVo;
    }
    /**
     * @param deUpdVo セットする deUpdVo
     */
    public void setDeUpdVo(List<Tbj13CampDetailVO> deUpdVo) {
        this._deUpdVo = deUpdVo;
    }

    /**
     * @return insOnlyFlg
     */
    public boolean getInsOnlyFlg() {
        return _insOnlyFlg;
    }
    /**
     * @param insOnlyFlg セットする insOnlyFlg
     */
    public void setInsOnlyFlg(boolean insOnlyFlg) {
        this._insOnlyFlg = insOnlyFlg;
    }
    /**
     * @return hamId
     */
    public String getHamId() {
        return _hamId;
    }
    /**
     * @param hamId セットする hamId
     */
    public void setHamId(String hamId) {
        this._hamId = hamId;
    }

    /**
     * @return hamNm
     */
    public String getHamNm() {
        return _hamNm;
    }
    /**
     * @param hamNm セットする hamNm
     */
    public void setHamNm(String hamNm) {
        this._hamNm = hamNm;
    }


    /**
     * @return updApl
     */
    public String getUpdApl() {
        return _updApl;
    }
    /**
     * @param updApl セットする updApl
     */
    public void setUpdApl(String updApl) {
        this._updApl = updApl;
    }


    /**
     * ダミープロパティを返します
     * @return
     */
    public String get_dummy() {
        return _dummy;
    }

    /**
     * ダミープロパティを設定する
     * @param
     */
    public void set_dummy(String dummy) {
        _dummy = dummy;
    }

    /**
     * データカウントを取得する
     * @return データカウント
     */
    public int getDataCount() {
        return _dataCount;
    }
    /**
     * データカウントを設定する
     * @param dataCount データカウント
     */
    public void setDataCount(int dataCount) {
        this._dataCount = dataCount;
    }

    /**
     * 最終更新者IDを取得する
     * @return 最終更新者ID
     */
    public String getLatestUpdId() {
        return _latestupdId;
    }
    /**
     * 最終更新者IDを設定する
     * @param latestupdId 最終更新者ID
     */
    public void setLatestUpdId(String latestupdId) {
        this._latestupdId = latestupdId;
    }

    /**
     * 最終更新日を取得する
     *
     * @return 最終更新日
     */
    @XmlElement(required = true)
    public Date getLatestDate() {
        return _latestDate;
    }

    /**
     * 最終更新日を取得する
     *
     * @param _latestDate 最終更新日
     */
    public void setLatestDate(Date latestDate) {
        this._latestDate = latestDate;
    }
}