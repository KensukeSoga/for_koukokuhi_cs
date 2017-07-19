package jp.co.isid.ham.billing.model;

import java.math.BigDecimal;
import java.util.List;

import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.nj.model.AbstractModel;

/**
 * <P>
 * 見積明細管理NOに紐付く制作費管理NOVO
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2013/3/1 T.Fujiyoshi)<BR>
 * </P>
 * @author T.Fujiyoshi
 */
@XmlRootElement(namespace = "http://model.billing.ham.isid.co.jp/")
@XmlType(namespace = "http://model.billing.ham.isid.co.jp/")
public class RelationSeqNoVO extends AbstractModel {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** 見積明細管理NO */
    BigDecimal _estDetailSeqNo;

    /** ソート順 */
    BigDecimal _sortNo;

    /** 見積明細管理NOに紐付く制作費管理NO */
    List<BigDecimal> _seqNoList;


    /**
     * 見積明細管理NOを取得する
     *
     * @return 見積明細管理NO
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getEstimateDetail() {
        return _estDetailSeqNo;
    }

    /**
     * 見積明細管理NOを設定する
     *
     * @param delEstimateDetail 見積明細管理NO
     */
    public void setEstimateDetail(BigDecimal estimateDetail) {
        _estDetailSeqNo = estimateDetail;
    }

    /**
     * ソート順を取得する
     *
     * @return ソート順
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getSortNo() {
        return _sortNo;
    }

    /**
     * ソート順を設定する
     *
     * @param sortNo ソート順
     */
    public void setSortNo(BigDecimal sortNo) {
        _sortNo = sortNo;
    }

    /**
     * 見積明細管理NOに紐付く制作費管理NOを取得する
     *
     * @return 見積明細管理NOに紐付く制作費管理NO
     */
    @XmlElement(required = true, nillable = true)
    public List<BigDecimal> getSeqNoList() {
        return _seqNoList;
    }

    /**
     * 見積明細管理NOに紐付く制作費管理NOを設定する
     *
     * @param seqNoList 見積明細管理NOに紐付く制作費管理NO
     */
    public void setSeqNoList(List<BigDecimal> seqNoList) {
        _seqNoList = seqNoList;
    }
}
