package jp.co.isid.ham.production.model;

import java.io.Serializable;
import java.util.Date;
import java.util.List;

import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.ham.common.model.Tbj19JasracVO;


/**
 * <P>
 * JASRAC情報登録　登録実行時の登録データ保持クラス
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2013/04/16 新HAMチーム)<BR>
 * </P>
 *
 * @author 新HAMチーム
 */
@XmlRootElement(namespace = "http://model.production.ham.isid.co.jp/")
@XmlType(namespace = "http://model.production.ham.isid.co.jp/")
public class RegistJasracVO implements Serializable
{
    /**
     * serialVersionUID
     */
    private static final long serialVersionUID = 1L;

    /** 契約種類（排他チェック用） */
    private String _exclusionCtrtkbnForJasrac;

    /** JASRAC情報件数 */
    private int _dataCount;

    /** JASRAC情報登録のタイムスタンプ最大値 */
    private Date _maxDateTimeForJasrac = null;

    /** JASRAC情報VO（登録）リスト */
    private List<Tbj19JasracVO> _tbj19JasracInsertVoListReg = null;

    /** JASRAC情報VO（更新）リスト */
    private List<Tbj19JasracVO> _tbj19JasracUpdateVoListUpd = null;

    /** JASRAC情報VO（更新）リスト */
    private List<Tbj19JasracVO> _tbj19JasracDeleteVoListDel = null;

    /**
     * 契約種類（排他チェック用）を取得する
     *
     * @return 契約種類（排他チェック用）
     */
    public String getExclusionCtrtkbnForJasrac()
    {
        return _exclusionCtrtkbnForJasrac;
    }

    /**
     * 契約種類（排他チェック用）を設定する
     *
     * @param exclusionCtrtkbnForJasrac 契約種類（排他チェック用）
     */
    public void setExclusionCtrtkbnForJasrac(String exclusionCtrtkbnForJasrac)
    {
        this._exclusionCtrtkbnForJasrac = exclusionCtrtkbnForJasrac;
    }

    /**
     * JASRAC情報件数を取得する
     *
     * @return JASRAC情報件数
     */
    public int getDataCount()
    {
        return _dataCount;
    }

    /**
     * JASRAC情報件数を設定する
     *
     * @param dataCount JASRAC情報件数
     */
    public void setDataCount(int dataCount)
    {
        this._dataCount = dataCount;
    }

    /**
     * JASRAC情報登録のタイムスタンプ最大値を取得する
     *
     * @return JASRAC情報登録のタイムスタンプ最大値
     */
    @XmlElement(required = true, nillable=true)
    public Date getMaxDateTimeForJasrac()
    {
        return _maxDateTimeForJasrac;
    }

    /**
     * JASRAC情報登録のタイムスタンプ最大値を設定する
     *
     * @param maxDateTimeForJasrac JASRAC情報登録のタイムスタンプ最大値
     */
    public void setMaxDateTimeForJasrac(Date maxDateTimeForJasrac)
    {
        this._maxDateTimeForJasrac = maxDateTimeForJasrac;
    }

    /**
     * JASRAC情報VO（登録）リストを取得する
     *
     * @return JASRAC情報VO（登録）リスト
     */
    public List<Tbj19JasracVO> getTbj19JASRACInsertVOListReg()
    {
        return _tbj19JasracInsertVoListReg;
    }

    /**
     * JASRAC情報VO（登録）を設定する
     *
     * @param tbj19JasracUpdateVoListReg JASRAC情報VO（登録）リスト
     */
    public void setTbj19JASRACInsertVOListReg(List<Tbj19JasracVO> tbj19JasracInsertVoListReg)
    {
        this._tbj19JasracInsertVoListReg = tbj19JasracInsertVoListReg;
    }

    /**
     * JASRAC情報VO（更新）リストを取得する
     *
     * @return JASRAC情報VO（更新）リスト
     */
    public List<Tbj19JasracVO> getTbj19JASRACUpdateVOListUpd()
    {
        return _tbj19JasracUpdateVoListUpd;
    }

    /**
     * JASRAC情報VO（更新）リストを設定する
     *
     * @param tbj19JasracUpdateVoListUpd JASRAC情報VO（更新）リスト
     */
    public void setTbj19JASRACUpdateVOListUpd(List<Tbj19JasracVO> tbj19JasracUpdateVoListUpd)
    {
        this._tbj19JasracUpdateVoListUpd = tbj19JasracUpdateVoListUpd;
    }

    /**
     * JASRAC情報VO（削除）リストを取得する
     *
     * @return JASRAC情報VO（削除）リスト
     */
    public List<Tbj19JasracVO> getTbj19JASRACDeleteVOListDel()
    {
        return _tbj19JasracDeleteVoListDel;
    }

    /**
     * JASRAC情報VO（削除）リストを設定する
     *
     * @param tbj19JasracDeleteVoListDel JASRAC情報VO（削除）リスト
     */
    public void setTbj19JASRACDeleteVOListDel(List<Tbj19JasracVO> tbj19JasracDeleteVoListDel)
    {
        this._tbj19JasracDeleteVoListDel = tbj19JasracDeleteVoListDel;
    }

}

