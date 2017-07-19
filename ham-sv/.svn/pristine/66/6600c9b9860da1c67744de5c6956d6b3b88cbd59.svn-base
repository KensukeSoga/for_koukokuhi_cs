package jp.co.isid.ham.mastermaintenance.model;

import java.math.BigDecimal;

import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.nj.model.AbstractModel;

/**
 * <P>
 * チェックデータVO
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/12/12 森)<BR>
 * </P>
 * @author 森
 */
@XmlRootElement(namespace = "http://model.mastermaintenance.ham.isid.co.jp/")
@XmlType(namespace = "http://model.mastermaintenance.ham.isid.co.jp/")
public class CheckRegistMasterMaintenanceVO extends AbstractModel
{
    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** データ数 */
    private BigDecimal _DATACOUNT = null;

    /**
     * デフォルトコンストラクタ
     */
    public CheckRegistMasterMaintenanceVO()
    {
    }

    /**
     * 新規インスタンスを生成する
     *
     * @return 新規インスタンス
     */
    public Object newInstance()
    {
        return new CheckRegistMasterMaintenanceVO();
    }

    /**
     * データ数を取得する
     *
     * @return データ数
     */
    public BigDecimal getDATACOUNT()
    {
        return _DATACOUNT;
    }

    /**
     * データ数を設定する
     *
     * @param val データ数
     */
    public void setDATACOUNT(BigDecimal val)
    {
        _DATACOUNT = val;
    }

}
