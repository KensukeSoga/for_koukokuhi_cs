package jp.co.isid.ham.mastermaintenance.model;

import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.ham.model.AbstractServiceResult;

/**
 * <P>
 * 機能制御表示情報Result
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/12/13 森)<BR>
 * </P>
 * @author 森
 */
@XmlRootElement(namespace = "http://model.mastermaintenance.ham.isid.co.jp/")
@XmlType(namespace = "http://model.mastermaintenance.ham.isid.co.jp/")
public class FindMasterMaintenanceFunctionControlDispResult extends AbstractServiceResult
{
    /** 機能制御スプレッドデータVO */
    private FindMasterMaintenanceFunctionControlSpreadVO _functionControlSpreadVO = null;

    /** 担当者検索データVO */
    private FindMbj02UserVO _userVO = null;

    /** 機能制御ベース検索データVO */
    private FindMbj39FunctionControlBaseVO _functionControlBaseVO = null;

    /**
     * 機能制御スプレッドデータVOを設定します
     * @param vo セットする _functionControlSpreadVO
     */
    public void setFunctionControlSpreadVO(FindMasterMaintenanceFunctionControlSpreadVO vo)
    {
        _functionControlSpreadVO = vo;
    }

    /**
     * 機能制御スプレッドデータVOを取得します
     * @return _functionControlSpreadVO
     */
    public FindMasterMaintenanceFunctionControlSpreadVO getFunctionControlSpreadVO()
    {
        return _functionControlSpreadVO;
    }

    /**
     * 担当者検索データVOを設定します
     * @param vo セットする _userVO
     */
    public void setUserVO(FindMbj02UserVO vo)
    {
        _userVO = vo;
    }

    /**
     * 担当者検索データVOを取得します
     * @return _userVO
     */
    public FindMbj02UserVO getUserVO()
    {
        return _userVO;
    }

    /**
     * 機能制御ベース検索データVOを設定します
     * @param vo セットする _functionControlBaseVO
     */
    public void setFunctionControlBaseVO(FindMbj39FunctionControlBaseVO vo)
    {
        _functionControlBaseVO = vo;
    }

    /**
     * 機能制御ベース検索データVOを取得します
     * @return _functionControlBaseVO
     */
    public FindMbj39FunctionControlBaseVO getFunctionControlBaseVO()
    {
        return _functionControlBaseVO;
    }

}
