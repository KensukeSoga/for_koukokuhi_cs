package jp.co.isid.ham.production.model;

import java.util.List;

import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.ham.common.model.FunctionControlInfoVO;
import jp.co.isid.ham.common.model.Mbj05CarVO;
import jp.co.isid.ham.common.model.Mbj12CodeVO;
import jp.co.isid.ham.common.model.Mbj37DisplayControlVO;
import jp.co.isid.ham.common.model.SecurityInfoVO;
import jp.co.isid.ham.common.model.Tbj16ContractInfoVO;
import jp.co.isid.ham.common.model.Tbj19JasracVO;
import jp.co.isid.ham.common.model.Tbj30DisplayPatternVO;
import jp.co.isid.ham.model.AbstractServiceResult;


/**
 * <P>
 * 取得Result
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2013/04/16 森)<BR>
 * </P>
 * @author 森
 */
@XmlRootElement(namespace = "http://model.production.ham.isid.co.jp/")
@XmlType(namespace = "http://model.production.ham.isid.co.jp/")
public class FindJasracResult extends AbstractServiceResult
{
    /** コードマスタVOリスト */
    private List<Mbj12CodeVO> _mbj12CodeVOList = null;

    /** 車種マスタVOリスト */
    private List<Mbj05CarVO> _mbj05CarVOList = null;

    /** 契約情報テーブルVOリスト */
    private List<Tbj16ContractInfoVO> _tbj16ContractInfoVOList = null;

    /** JASRAC情報テーブルVOリスト */
    private List<Tbj19JasracVO> _tbj19JasracVOList = null;

    /** 画面項目表示列制御マスタ */
    private List<Mbj37DisplayControlVO> _mbj37DisplayControlVoList = null;

    /** 画面項目表示列制御テーブル */
    private List<Tbj30DisplayPatternVO> _tbj30DisplayPatternVoList = null;

    /** 機能制御Info */
    private List<FunctionControlInfoVO> _functionControlInfoVoList = null;

    /** セキュリティ情報 */
    private List<SecurityInfoVO> _securityInfoVoList = null;

    /**
     * コードマスタVOリストを取得する
     * @return コードマスタVOリスト
     */
    public List<Mbj12CodeVO> getMbj12CodeVOList()
    {
        return _mbj12CodeVOList;
    }

    /**
     * コードマスタVOリストを設定する
     * @param mbj12CodeVOList コードマスタVOリスト
     */
    public void setMbj12CodeVOList(List<Mbj12CodeVO> mbj12CodeVOList)
    {
        this._mbj12CodeVOList = mbj12CodeVOList;
    }

    /**
     * 車種マスタVOリストを取得する
     * @return 車種マスタVOリスト
     */
    public List<Mbj05CarVO> getMbj05CarVOList()
    {
        return _mbj05CarVOList;
    }

    /**
     * 車種マスタVOリストを設定する
     * @param mbj05CarVOList 車種マスタVOリスト
     */
    public void setMbj05CarVOList(List<Mbj05CarVO> mbj05CarVOList)
    {
        this._mbj05CarVOList = mbj05CarVOList;
    }

    /**
     * 契約情報テーブルVOリストを取得する
     * @return 契約情報テーブルVOリスト
     */
    public List<Tbj16ContractInfoVO> getTbj16ContractInfoVOList()
    {
        return _tbj16ContractInfoVOList;
    }

    /**
     * 契約情報テーブルVOリストを設定する
     * @param tbj16ContractInfoVOList 契約情報テーブルVOリスト
     */
    public void setTbj16ContractInfoVOList(List<Tbj16ContractInfoVO> tbj16ContractInfoVOList)
    {
        this._tbj16ContractInfoVOList = tbj16ContractInfoVOList;
    }

    /**
     * JASRAC情報テーブルVOリストを取得する
     * @return JASRAC情報テーブルVOリスト
     */
    public List<Tbj19JasracVO> getTbj19JasracVOList()
    {
        return _tbj19JasracVOList;
    }

    /**
     * JASRAC情報テーブルVOリストを設定する
     * @param tbj19JasracVOList JASRAC情報テーブルVOリスト
     */
    public void setTbj19JasracVOList(List<Tbj19JasracVO> tbj19JasracVOList)
    {
        this._tbj19JasracVOList = tbj19JasracVOList;
    }

    /**
     * 画面項目表示列制御マスタVOリストを取得する
     * @return 画面項目表示列制御マスタVOリスト
     */
    public List<Mbj37DisplayControlVO> getMbj37DisplayControlVoList()
    {
        return _mbj37DisplayControlVoList;
    }

    /**
     * 画面項目表示列制御マスタVOリストを設定する
     * @param mbj37DisplayControlVoList 画面項目表示列制御マスタVOリスト
     */
    public void setMbj37DisplayControlVoList(List<Mbj37DisplayControlVO> mbj37DisplayControlVoList)
    {
        this._mbj37DisplayControlVoList = mbj37DisplayControlVoList;
    }

    /**
     * 一覧表示パターンVOリストを設定する
     * @param val 一覧表示パターンVOリスト
     */
    public void setTbj30DisplayPatternVoList(List<Tbj30DisplayPatternVO> val)
    {
        this._tbj30DisplayPatternVoList = val;
    }


    /**
     * 一覧表示パターンVOリストを取得する
     * @return 一覧表示パターンVOリスト
     */
    public List<Tbj30DisplayPatternVO> getTbj30DisplayPatternVoList()
    {
        return _tbj30DisplayPatternVoList;
    }

    /**
     * 機能制御InfoVOリストを取得する
     * @return 機能制御InfoVOリスト
     */
    public List<FunctionControlInfoVO> getFunctionControlInfoVoList() {
        return _functionControlInfoVoList;
    }

    /**
     * 機能制御InfoVOリストを設定する
     * @param secinfo 機能制御InfoVOリスト
     */
    public void setFunctionControlInfoVoList(List<FunctionControlInfoVO> functionControlInfoVoList) {
        _functionControlInfoVoList = functionControlInfoVoList;
    }

    /**
     * セキュリティ情報VOリストを取得します
     * @return セキュリティ情報VOリスト
     */
    public List<SecurityInfoVO> getSecurityInfoVoList()
    {
        return _securityInfoVoList;
    }

    /**
     * セキュリティ情報VOリストを設定します
     * @param securityInfoVoList セキュリティ情報VOリスト
     */
    public void setSecurityInfoVoList(List<SecurityInfoVO> securityInfoVoList)
    {
        _securityInfoVoList = securityInfoVoList;
    }

}
