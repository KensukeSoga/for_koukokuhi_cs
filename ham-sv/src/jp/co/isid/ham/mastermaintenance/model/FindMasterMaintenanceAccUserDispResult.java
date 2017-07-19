package jp.co.isid.ham.mastermaintenance.model;

import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.ham.model.AbstractServiceResult;

/**
 * <P>
 * 個人情報View表示情報Result
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2013/02/08 森)<BR>
 * </P>
 * @author 森
 */
@XmlRootElement(namespace = "http://model.mastermaintenance.ham.isid.co.jp/")
@XmlType(namespace = "http://model.mastermaintenance.ham.isid.co.jp/")
public class FindMasterMaintenanceAccUserDispResult extends AbstractServiceResult
{
    /** 個人情報View検索データVO */
    private FindMasterMaintenanceAccUserVO _accUserVO = null;

    /**
     * 個人情報View検索データVOを設定します
     * @param vo セットする _accUserVO
     */
    public void setAccUserVO(FindMasterMaintenanceAccUserVO vo)
    {
        _accUserVO = vo;
    }

    /**
     * 個人情報View検索データVOを取得します
     * @return _accUserVO
     */
    public FindMasterMaintenanceAccUserVO getAccUserVO()
    {
        return _accUserVO;
    }

}
