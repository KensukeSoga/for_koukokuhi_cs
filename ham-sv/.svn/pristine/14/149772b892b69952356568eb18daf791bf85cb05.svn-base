package jp.co.isid.ham.billing.model;

import java.math.BigDecimal;

import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.nj.model.AbstractModel;
/**
 * <P>
 * 制作費取込VO
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2013/4/2 J.Kamiyama)<BR>
 * </P>
 * @author J.Kamiyama
 */
@XmlRootElement(namespace = "http://model.billing.ham.isid.co.jp/")
@XmlType(namespace = "http://model.billing.ham.isid.co.jp/")
public class CheckBillProductionVO extends AbstractModel {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** データ数 */
    private BigDecimal _DATACOUNT = null;

    /**
     * デフォルトコンストラクタ
     */
    public CheckBillProductionVO() {
    }

    /**
     * 新規インスタンスを生成する
     *
     * @return 新規インスタンス
     */
    @Override
    public Object newInstance() {
        return new CheckBillProductionVO();
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
