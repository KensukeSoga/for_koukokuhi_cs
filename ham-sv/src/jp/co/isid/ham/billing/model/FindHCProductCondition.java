package jp.co.isid.ham.billing.model;

import java.io.Serializable;
import java.util.List;

import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

/**
 * <P>
 * HC商品マスタ検索条件
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2013/2/16 T.Fujiyoshi)<BR>
 * </P>
 * @author T.Fujiyoshi
 */
@XmlRootElement(namespace = "http://model.billing.ham.isid.co.jp/")
@XmlType(namespace = "http://model.billing.ham.isid.co.jp/")
public class FindHCProductCondition implements Serializable {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** HC部門コード */
    private List<String> _HCBumonCd;

    /** 商品コード */
    private List<String> _productCd;


    /**
     * HC部門コードを取得する
     *
     * @return HC部門コード
     */
    public List<String> getHCBumonCd() {
        return _HCBumonCd;
    }

    /**
     * HC部門コードを設定する
     *
     * @param HCBumonCd HC部門コード
     */
    public void setHCBumonCd(List<String> HCBumonCd) {
        _HCBumonCd = HCBumonCd;
    }

    /**
     * 商品コードを取得する
     *
     * @return 商品コード
     */
    public List<String> getProductCd() {
        return _productCd;
    }

    /**
     * 商品コードを設定する
     *
     * @param productCd 商品コード
     */
    public void setProductCd(List<String> productCd) {
        _productCd = productCd;
    }

}
