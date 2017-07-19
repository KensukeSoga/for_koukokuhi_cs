package jp.co.isid.ham.billing.model;

import java.io.Serializable;
import java.math.BigDecimal;
import java.util.List;

import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

/**
 * <P>
 * HM見積案件CR制作費検索条件
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2015/08/31 HLC S.Fujimoto)<BR>
 * </P>
 * @author S.Fujimoto
 */
@XmlRootElement(namespace = "http://model.billing.ham.isid.co.jp/")
@XmlType(namespace = "http://model.billing.ham.isid.co.jp/")
public class FindHMEstimateCreateCondition implements Serializable {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** 見積明細管理NOリスト */
    List<BigDecimal> _estSeqNoList;

    /**
     * 見積明細管理NOを取得する
     * @return List<BigDecimal> 見積明細管理NOリスト
     */
    public List<BigDecimal> getEstSeqNoList() {
        return _estSeqNoList;
    }

    /**
     * 見積明細管理NOリストを設定する
     * @param estDetailSeqNo List<BigDecimal> 見積明細管理NOリスト
     */
    public void setEstSeqNoList(List<BigDecimal> val) {
        _estSeqNoList = val;
    }

}
