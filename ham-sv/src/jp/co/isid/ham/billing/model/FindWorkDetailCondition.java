/**
 *
 */
package jp.co.isid.ham.billing.model;

import java.io.Serializable;
import java.math.BigDecimal;

import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

/**
 * @author lis7y1
 *
 */
/**
 * <P>
 * �����׏��o�͌�������
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2013/4/4 T.Kobayashi)<BR>
 * </P>
 * @author T.Kobayashi
 */
@XmlRootElement(namespace = "http://model.billing.ham.isid.co.jp/")
@XmlType(namespace = "http://model.billing.ham.isid.co.jp/")
public class FindWorkDetailCondition implements Serializable {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** �t�F�C�Y */
    private int _phase;

    /** �N�� */
    private String _crDate;

    /** �d�ʎԎ�R�[�h */
    private String _dCarCd;

    /** �敪�R�[�h */
    private String _divCd;

    /** �O���[�v�R�[�h */
    private BigDecimal _groupCd;

    /** ���ψČ��Ǘ�NO */
    private BigDecimal _estSeqNo;

    /**
     * �t�F�C�Y���擾���܂�
     *
     * @return �t�F�C�Y
     */
    public int getPhase() {
        return _phase;
    }

    /**
     * �t�F�C�Y��ݒ肵�܂�
     *
     * @param phase �t�F�C�Y
     */
    public void setPhase(int phase) {
        _phase = phase;
    }

    /**
     * �N�����擾���܂�
     *
     * @return �N��
     */
    public String getCrDate() {
        return _crDate;
    }

    /**
     * �N����ݒ肵�܂�
     *
     * @param crDate �N��
     */
    public void setCrDate(String crDate) {
    	_crDate = crDate;
    }

    /**
     * �d�ʎԎ�R�[�h���擾���܂�
     *
     * @return �d�ʎԎ�R�[�h
     */
    public String getDCarCd() {
        return _dCarCd;
    }

    /**
     * �d�ʎԎ�R�[�h��ݒ肵�܂�
     *
     * @param dCarCd �d�ʎԎ�R�[�h
     */
    public void setDCarCd(String dCarCd) {
    	_dCarCd = dCarCd;
    }

    /**
     * �敪�R�[�h���擾���܂�
     *
     * @return �敪�R�[�h
     */
    public String getDivCd() {
        return _divCd;
    }

    /**
     * �敪�R�[�h��ݒ肵�܂�
     *
     * @param divCd �敪�R�[�h
     */
    public void setDivCd(String divCd) {
    	_divCd = divCd;
    }

    /**
     * �O���[�v�R�[�h���擾���܂�
     *
     * @return �O���[�v�R�[�h
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getGroupCd() {
        return _groupCd;
    }

    /**
     * �O���[�v�R�[�h��ݒ肵�܂�
     *
     * @param groupCd �O���[�v�R�[�h
     */
    public void setGroupCd(BigDecimal groupCd) {
    	_groupCd = groupCd;
    }

    /**
     * ���ψČ��Ǘ�NO���擾���܂�
     *
     * @return ���ψČ��Ǘ�NO
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getEstSeqNo() {
        return _estSeqNo;
    }

    /**
     * ���ψČ��Ǘ�NO��ݒ肵�܂�
     *
     * @param estSeqNo ���ψČ��Ǘ�NO
     */
    public void setEstSeqNo(BigDecimal estSeqNo) {
    	_estSeqNo = estSeqNo;
    }
}