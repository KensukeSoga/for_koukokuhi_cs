package jp.co.isid.ham.mastermaintenance.model;

import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.ham.model.AbstractServiceResult;

/**
 * <P>
 * 過去ロック表示情報Result
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/12/04 森)<BR>
 * </P>
 * @author 森
 */
@XmlRootElement(namespace = "http://model.mastermaintenance.ham.isid.co.jp/")
@XmlType(namespace = "http://model.mastermaintenance.ham.isid.co.jp/")
public class FindMasterMaintenanceLockDispResult extends AbstractServiceResult
{
    /** 過去ロック検索データVO */
    private FindMbj01SysStsVO _lockVO = null;

    /**
     * 過去ロック検索データVOを設定します
     * @param vo セットする _lockVO
     */
    public void setLockVO(FindMbj01SysStsVO vo)
    {
        _lockVO = vo;
    }

    /**
     * 過去ロック検索データVOを取得します
     * @return _lockVO
     */
    public FindMbj01SysStsVO getLockVO()
    {
        return _lockVO;
    }

}
