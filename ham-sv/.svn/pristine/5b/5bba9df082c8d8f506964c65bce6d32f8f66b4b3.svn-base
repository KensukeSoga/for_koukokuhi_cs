package jp.co.isid.ham.mastermaintenance.model;

import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.ham.model.AbstractServiceResult;

/**
 * <P>
 * 系列表示情報Result
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/12/06 神山)<BR>
 * </P>
 * @author 神山
 */
@XmlRootElement(namespace = "http://model.mastermaintenance.ham.isid.co.jp/")
@XmlType(namespace = "http://model.mastermaintenance.ham.isid.co.jp/")
public class FindMasterMaintenanceSeriesDispResult extends AbstractServiceResult
{
    /** 系列検索データVO */
    private FindMbj04KeiretsuVO _seriesVO = null;

    /**
     * 系列検索データVOを設定します
     * @param vo セットする _seriesVO
     */
    public void setSeriesVO(FindMbj04KeiretsuVO vo)
    {
        _seriesVO = vo;
    }

    /**
     * 系列検索データVOを取得します
     * @return _seriesVO
     */
    public FindMbj04KeiretsuVO getSeriesVO()
    {
        return _seriesVO;
    }

}
