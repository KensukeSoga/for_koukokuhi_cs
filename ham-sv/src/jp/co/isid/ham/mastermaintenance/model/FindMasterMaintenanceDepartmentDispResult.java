package jp.co.isid.ham.mastermaintenance.model;

import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.ham.model.AbstractServiceResult;

/**
 * <P>
 * 部署表示情報Result
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/12/11 森)<BR>
 * </P>
 * @author 森
 */
@XmlRootElement(namespace = "http://model.mastermaintenance.ham.isid.co.jp/")
@XmlType(namespace = "http://model.mastermaintenance.ham.isid.co.jp/")
public class FindMasterMaintenanceDepartmentDispResult extends AbstractServiceResult
{
    /** 部署検索データVO */
    private FindMbj32DepartmentVO _departmentVO = null;

    /** コードマスタ検索データVO */
    private FindMbj12CodeVO _codeVO = null;

    /**
     * 部署検索データVOを設定します
     * @param vo セットする _departmentVO
     */
    public void setDepartmentVO(FindMbj32DepartmentVO vo)
    {
        _departmentVO = vo;
    }

    /**
     * 部署検索データVOを取得します
     * @return _departmentVO
     */
    public FindMbj32DepartmentVO getDepartmentVO()
    {
        return _departmentVO;
    }

    /**
     * コードマスタ検索データVOを設定します
     * @param vo セットする _codeVO
     */
    public void setCodeVO(FindMbj12CodeVO vo)
    {
        _codeVO = vo;
    }

    /**
     * コードマスタ検索データVOを取得します
     * @return _codeVO
     */
    public FindMbj12CodeVO getCodeVO()
    {
        return _codeVO;
    }

}
