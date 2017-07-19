package jp.co.isid.ham.billing.model;

import java.io.Serializable;
import java.math.BigDecimal;
import java.util.List;

import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

/**
 * <P>
 * HC���ψꗗ�ύX�m�F(�����)�f�[�^��������
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2013/3/21 T.Fujiyoshi)<BR>
 * </P>
 * @author T.Fujiyoshi
 */
@XmlRootElement(namespace = "http://model.billing.ham.isid.co.jp/")
@XmlType(namespace = "http://model.billing.ham.isid.co.jp/")
public class FindHCEstimateListDiffTotalCondition implements Serializable {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /**
     * ���ψČ��Ǘ�NO
     */
    private List<BigDecimal> _estSeqNoList;

    /**
     * �t�F�C�Y
     */
    private BigDecimal _phase = BigDecimal.valueOf(0);

    /**
     * �N��
     */
    private String _yearMonth = null;


    /**
     * ���ψČ��Ǘ�NO���擾����
     *
     * @return ���ψČ��Ǘ�NO
     */
    @XmlElement(required = true, nillable = true)
    public List<BigDecimal> getEstSeqNoList() {
        return _estSeqNoList;
    }

    /**
     * ���ψČ��Ǘ�NO��ݒ肷��
     *
     * @param estSeqNo ���ψČ��Ǘ�NO
     */
    public void setEstSeqNoList(List<BigDecimal> estSeqNo) {
        _estSeqNoList = estSeqNo;
    }

    /**
     * �t�F�C�Y���擾����
     *
     * @return �t�F�C�Y
     */
    public BigDecimal getPhase() {
        return _phase;
    }

    /**
     * �t�F�C�Y��ݒ肷��
     *
     * @param phase �t�F�C�Y
     */
    public void setPhase(BigDecimal phase) {
        _phase = phase;
    }

    /**
     * �N�����擾����
     *
     * @return �N��
     */
    public String getYearMonth() {
        return _yearMonth;
    }

    /**
     * �N����ݒ肷��
     *
     * @param yearMonth �N��
     */
    public void setYearMonth(String yearMonth) {
        _yearMonth = yearMonth;
    }
}
