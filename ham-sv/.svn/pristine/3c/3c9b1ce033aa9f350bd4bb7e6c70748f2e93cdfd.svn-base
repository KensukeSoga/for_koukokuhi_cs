package jp.co.isid.ham.production.model;

import java.io.Serializable;
import java.math.BigDecimal;
import java.util.Date;
import java.util.List;
import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;
import jp.co.isid.ham.common.model.Tbj11CrCreateDataVO;

/**
 * <P>
 * CR制作費―データ移動／コピー　登録実行時の登録データ保持クラス
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
public class MoveCrCreateDataVO implements Serializable {

    /**
     * serialVersionUID
     */
    private static final long serialVersionUID = 1L;

    /** 担当者ID */
    private String _userid = null;

    /** 担当者名 */
    private String _usernm = null;

    /** 画面ID */
    private String _formid = null;

    /** CR制作費管理の最大タイムスタンプ */
    private Date _maxDateTimeForCrCreateData = null;

    /** CR制作費管理VOリスト */
    private List<Tbj11CrCreateDataVO> _tbj11CrCreateDataVoList = null;

    /** 電通車種コード */
    private String _dCarCd = null;

    /** フェイズ */
    private BigDecimal _phase = null;

    /** 年月 */
    private Date _crDate = null;

    /** 種別判断フラグ */
    private String _classDiv = null;

    /** 処理種別(0:移動、1:コピー) */
    private int _execKind = 0;

    /**
     * 担当者IDを取得する
     *
     * @return 担当者ID
     */
    public String getUserid() {
        return _userid;
    }

    /**
     * 担当者IDを設定する
     *
     * @param userid 担当者ID
     */
    public void setUserid(String userid) {
        this._userid = userid;
    }

    /**
     * 担当者名を取得する
     *
     * @return 担当者名
     */
    public String getUsernm() {
        return _usernm;
    }

    /**
     * 担当者名を設定する
     *
     * @param userid 担当者名
     */
    public void setUsernm(String usernm) {
        this._usernm = usernm;
    }

    /**
     * 画面IDを取得する
     *
     * @return 画面ID
     */
    public String getFormid() {
        return _formid;
    }

    /**
     * 画面IDを設定する
     *
     * @param formid 画面ID
     */
    public void setFormid(String formid) {
        this._formid = formid;
    }

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
     * CR制作費管理VO（登録）リストを取得する
     *
     * @return CR制作費管理VO（登録）リスト
     */
    @XmlElement(required = true, nillable=true)
    public List<Tbj11CrCreateDataVO> getTbj11CrCreateDataVoList() {
        return _tbj11CrCreateDataVoList;
    }

    /**
     * CR制作費管理VO（登録）リストを設定する
     *
     * @param tbj11CrCreateDataVoListReg CR制作費管理VO（登録）リスト
     */
    public void setTbj11CrCreateDataVoList(List<Tbj11CrCreateDataVO> tbj11CrCreateDataVoList) {
        this._tbj11CrCreateDataVoList = tbj11CrCreateDataVoList;
    }

    /**
     * 電通車種コードを取得する
     *
     * @return 電通車種コード
     */
    public String getDCarCd() {
        return _dCarCd;
    }

    /**
     * 電通車種コードを設定する
     *
     * @param dcarcd 電通車種コード
     */
    public void setDCarCd(String dCarCd) {
        this._dCarCd = dCarCd;
    }

    /**
     * フェイズを取得する
     *
     * @return フェイズ
     */
    @XmlElement(required = true, nillable=true)
    public BigDecimal getPhase() {
        return _phase;
    }

    /**
     * フェイズを設定する
     *
     * @param phase フェイズ
     */
    public void setPhase(BigDecimal phase) {
        this._phase = phase;
    }

    /**
     * 年月を取得する
     *
     * @return 年月
     */
    @XmlElement(required = true, nillable=true)
    public Date getCrDate() {
        return _crDate;
    }

    /**
     * 年月を設定する
     *
     * @param crdate 年月
     */
    public void setCrDate(Date crDate) {
        this._crDate = crDate;
    }

    /**
     * 種別判断フラグを取得する
     *
     * @return 種別判断フラグ
     */
    public String getClassDiv() {
        return _classDiv;
    }

    /**
     * 種別判断フラグを設定する
     *
     * @param dcarcd 電通車種コード
     */
    public void setClassDiv(String classDiv) {
        this._classDiv = classDiv;
    }

    /**
     * 処理種別を取得する
     *
     * @return 処理種別
     */
    public int getExecKind() {
        return _execKind;
    }

    /**
     * 処理種別を設定する
     *
     * @param dcarcd 処理種別
     */
    public void setExecKind(int execKind) {
        this._execKind = execKind;
    }


}
