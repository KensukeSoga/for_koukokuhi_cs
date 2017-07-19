package jp.co.isid.ham.mastermaintenance.model;

import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.ham.model.AbstractServiceResult;

/**
 * <P>
 * メール配信表示情報Result
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2013/02/07 森)<BR>
 * </P>
 * @author 森
 */
@XmlRootElement(namespace = "http://model.mastermaintenance.ham.isid.co.jp/")
@XmlType(namespace = "http://model.mastermaintenance.ham.isid.co.jp/")
public class FindMasterMaintenanceAlertMailAddressDispResult extends AbstractServiceResult
{
    /** メール配信検索データVO */
    private FindMbj40AlertMailAddressVO _alartMailAddressVO = null;

    /** コードマスタ検索データVO */
    private FindMbj12CodeVO _codeVO = null;

    /**
     * メール配信検索データVOを設定します
     * @param vo セットする _alartMailAddressVO
     */
    public void setAlertMailAddressVO(FindMbj40AlertMailAddressVO vo)
    {
        _alartMailAddressVO = vo;
    }

    /**
     * メール配信検索データVOを取得します
     * @return _alartMailAddressVO
     */
    public FindMbj40AlertMailAddressVO getAlertMailAddressVO()
    {
        return _alartMailAddressVO;
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
