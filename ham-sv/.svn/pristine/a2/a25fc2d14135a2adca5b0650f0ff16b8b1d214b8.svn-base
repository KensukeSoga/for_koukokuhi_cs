package jp.co.isid.ham.mastermaintenance.model;

import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.nj.model.AbstractModel;

/**
 * <P>
 * 系列表示登録データVO
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/12/06 神山)<BR>
 * </P>
 * @author 神山
 */
@XmlRootElement(namespace = "http://model.mastermaintenance.ham.isid.co.jp/")
@XmlType(namespace = "http://model.mastermaintenance.ham.isid.co.jp/")
public class RegistMasterMaintenanceSeriesDispVO extends AbstractModel
{
    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** 系列登録データVO */
    private RegistMbj04KeiretsuVO _SeriesVO = null;

    /**
     * デフォルトコンストラクタ
     */
    public RegistMasterMaintenanceSeriesDispVO()
    {
    }

    /**
     * 新規インスタンスを生成する
     *
     * @return 新規インスタンス
     */
    public Object newInstance()
    {
        return new RegistMasterMaintenanceSeriesDispVO();
    }

    /**
     * 系列登録データVOを設定します
     * @param vo セットする _SeriesVO
     */
    public void setSeriesVO(RegistMbj04KeiretsuVO vo)
    {
        _SeriesVO = vo;
    }

    /**
     * 系列登録データVOを取得します
     * @return _SeriesVO
     */
    public RegistMbj04KeiretsuVO getSeriesVO()
    {
        return _SeriesVO;
    }

}
