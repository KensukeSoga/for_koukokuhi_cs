package jp.co.isid.ham.production.model;

import java.io.Serializable;
import java.math.BigDecimal;
import java.util.List;

import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

/**
 * <P>
 * CR�����@�ύX���e�ʒm�������s���̃f�[�^�擾�����N���X
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2013/06/24 �VHAM�`�[��)<BR>
 * </P>
 *
 * @author �VHAM�`�[��
 */
@XmlRootElement(namespace = "http://model.production.ham.isid.co.jp/")
@XmlType(namespace = "http://model.production.ham.isid.co.jp/")
public class FindChangeNoticeCondition implements Serializable {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** �S����ID */
    private String _hamid = null;

    /** �d�ʎԎ�R�[�h */
    private String _dCarCd = null;

    /** �t�F�C�Y */
    private BigDecimal _phase = null;

    /** �X�V�N��(YYYYMM) */
    private String _updMonth = null;

    /** �����Ǘ�NO */
    private List<BigDecimal> _sequencenoList = null;

    /**
     * �S����ID���擾����
     *
     * @return �S����ID
     */
    public String getHamid() {
        return _hamid;
    }

    /**
     * �S����ID��ݒ肷��
     *
     * @param hamid �S����ID
     */
    public void setHamid(String hamid) {
        this._hamid = hamid;
    }

    /**
     * �d�ʎԎ�R�[�h���擾����
     *
     * @return �d�ʎԎ�R�[�h
     */
    public String getDCarCd() {
        return _dCarCd;
    }

    /**
     * �d�ʎԎ�R�[�h��ݒ肷��
     *
     * @param dcarcd �d�ʎԎ�R�[�h
     */
    public void setDCarCd(String dCarCd) {
        this._dCarCd = dCarCd;
    }

    /**
     * �t�F�C�Y���擾����
     *
     * @return �t�F�C�Y
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getPhase() {
        return _phase;
    }

    /**
     * �t�F�C�Y��ݒ肷��
     *
     * @param phase �t�F�C�Y
     */
    public void setPhase(BigDecimal phase) {
        this._phase = phase;
    }

    /**
     * �X�V�N��(YYYYMM)���擾����
     *
     * @return �X�V�N��(YYYYMM)
     */
    public String getUpdMonth() {
        return _updMonth;
    }

    /**
     * �X�V�N��(YYYYMM)��ݒ肷��
     *
     * @param updMonth �X�V�N��(YYYYMM)
     */
    public void setUpdMonth(String updMonth) {
        this._updMonth = updMonth;
    }

    /**
     * �����Ǘ�NO���擾����
     *
     * @return �����Ǘ�NO
     */
    @XmlElement(required = true, nillable = true)
    public List<BigDecimal> getSequencenoList() {
        return _sequencenoList;
    }

    /**
     * �����Ǘ�NO��ݒ肷��
     *
     * @param sequencenoList �����Ǘ�NO�̃��X�g
     */
    public void setSequencenoList(List<BigDecimal> sequencenoList) {
        this._sequencenoList = sequencenoList;
    }
}
