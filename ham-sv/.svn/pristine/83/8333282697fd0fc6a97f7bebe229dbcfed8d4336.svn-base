package jp.co.isid.ham.billing.model;

import java.math.BigDecimal;

import javax.xml.bind.annotation.XmlElement;

import jp.co.isid.ham.integ.tbl.Tbj07EstimateCreate;

/**
 * <P>
 * 制作費明細書出力一覧取得VO
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2013/4/5 T.Kobayashi)<BR>
 * </P>
 * @author T.Kobayashi
 */
public class FindWorkDetailListItemVO extends FindEstimateDetailVO {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /**
     * デフォルトコンストラクタ
     */
    public FindWorkDetailListItemVO() {
    }

    /**
     * 新規インスタンスを生成する
     *
     * @return 新規インスタンス
     */
    @Override
    public Object newInstance() {
        return new FindWorkDetailListItemVO();
    }

    /**
     * 制作費管理NOを取得する
     *
     * @return 制作費管理NO
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getSEQUENCENO() {
        return (BigDecimal) get(Tbj07EstimateCreate.SEQUENCENO);
    }

    /**
     * 制作費管理NOを設定する
     *
     * @param val 制作費管理NO
     */
    public void setSEQUENCENO(BigDecimal val) {
        set(Tbj07EstimateCreate.SEQUENCENO, val);
    }
}
