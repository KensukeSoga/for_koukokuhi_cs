package jp.co.isid.ham.production.model;

import java.io.Serializable;
import java.math.BigDecimal;
import java.util.Date;

import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

/**
 * <P>
 * CR�����@�������s���̃f�[�^�擾�����N���X
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2012/12/05 �VHAM�`�[��)<BR>
 * </P>
 *
 * @author �VHAM�`�[��
 */
@XmlRootElement(namespace = "http://model.production.ham.isid.co.jp/")
@XmlType(namespace = "http://model.production.ham.isid.co.jp/")
public class FindLogCrCreateDataCondition implements Serializable {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** �S����ID */
    private String _hamid = null;

    /** �d�ʎԎ�R�[�h */
    private String _dCarCd = null;

    /** �t�F�C�Y */
    private BigDecimal _phase = null;

    /** �N�� */
    private Date _crDate = null;

    /** �����Ǘ�NO */
    private BigDecimal _sequenceno = null;

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
    @XmlElement(required = true)
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
     * �N�����擾����
     *
     * @return �N��
     */
    @XmlElement(required = true)
    public Date getCrDate() {
        return _crDate;
    }

    /**
     * �N����ݒ肷��
     *
     * @param crdate �N��
     */
    public void setCrDate(Date crDate) {
        this._crDate = crDate;
    }

    /**
     * �����Ǘ�NO���擾����
     *
     * @return �����Ǘ�NO
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getSequenceno() {
        return _sequenceno;
    }

    /**
     * �����Ǘ�NO��ݒ肷��
     *
     * @param sequenceno �����Ǘ�NO
     */
    public void setSequenceno(BigDecimal sequenceno) {
        this._sequenceno = sequenceno;
    }
}