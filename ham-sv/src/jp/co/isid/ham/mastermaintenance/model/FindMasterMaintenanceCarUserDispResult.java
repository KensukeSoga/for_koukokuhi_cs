package jp.co.isid.ham.mastermaintenance.model;

import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.ham.model.AbstractServiceResult;

/**
 * <P>
 * 車種担当表示情報Result
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/12/12 森)<BR>
 * </P>
 * @author 森
 */
@XmlRootElement(namespace = "http://model.mastermaintenance.ham.isid.co.jp/")
@XmlType(namespace = "http://model.mastermaintenance.ham.isid.co.jp/")
public class FindMasterMaintenanceCarUserDispResult extends AbstractServiceResult
{
    /** 車種担当スプレッド検索データVO */
    private FindMasterMaintenanceCarUserSpreadVO _carUserSpreadVO = null;

    /**
     * 車種担当スプレッド検索データVOを設定します
     * @param vo セットする _carUserSpreadVO
     */
    public void setCarUserSpreadVO(FindMasterMaintenanceCarUserSpreadVO vo)
    {
        _carUserSpreadVO = vo;
    }

    /**
     * 車種担当スプレッド検索データVOを取得します
     * @return _carUserSpreadVO
     */
    public FindMasterMaintenanceCarUserSpreadVO getCarUserSpreadVO()
    {
        return _carUserSpreadVO;
    }

}
