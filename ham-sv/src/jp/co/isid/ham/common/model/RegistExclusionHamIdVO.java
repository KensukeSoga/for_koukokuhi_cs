package jp.co.isid.ham.common.model;

import java.util.Date;

import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.nj.model.AbstractModel;

/**
 * <P>
 * �r�����b�N���VO�iHamId�j
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2012/12/18 �X)<BR>
 * </P>
 * @author �X
 */
@XmlRootElement(namespace = "http://model.common.ham.isid.co.jp/")
@XmlType(namespace = "http://model.common.ham.isid.co.jp/")
public class RegistExclusionHamIdVO extends AbstractModel
{
    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** �f�[�^�� */
    private String _DATACOUNT = null;

    /** �ŐV�X�V���� */
    private Date _UPDATEDATE = null;

    /** �ŐV�X�V��ID */
    private String _UPDATEUSERID = null;

    /** �S����ID�i�`�F�b�N�f�[�^�i�荞�ݗp�j */
    private String _HAMID = null;

    /**
     * �f�t�H���g�R���X�g���N�^
     */
    public RegistExclusionHamIdVO()
    {
    }

    /**
     * �V�K�C���X�^���X�𐶐�����
     *
     * @return �V�K�C���X�^���X
     */
    public Object newInstance()
    {
        return new RegistExclusionHamIdVO();
    }

    /**
     * �f�[�^�����擾����
     *
     * @return �f�[�^��
     */
    public String getDATACOUNT()
    {
        return _DATACOUNT;
    }

    /**
     * �f�[�^����ݒ肷��
     *
     * @param val �f�[�^��
     */
    public void setDATACOUNT(String val)
    {
        _DATACOUNT = val;
    }

    /**
     * �ŐV�X�V�������擾����
     *
     * @return �ŐV�X�V����
     */
    @XmlElement(required = true, nillable = true)
    public Date getUPDATEDATE()
    {
        return _UPDATEDATE;
    }

    /**
     * �ŐV�X�V������ݒ肷��
     *
     * @param val �ŐV�X�V����
     */
    public void setUPDATEDATE(Date val)
    {
        _UPDATEDATE = val;
    }

    /**
     * �ŐV�X�V��ID���擾����
     *
     * @return �ŐV�X�V��ID
     */
    public String getUPDATEUSERID()
    {
        return _UPDATEUSERID;
    }

    /**
     * �ŐV�X�V��ID��ݒ肷��
     *
     * @param val �ŐV�X�V��ID
     */
    public void setUPDATEUSERID(String val)
    {
        _UPDATEUSERID = val;
    }

    /**
     * �S����ID�i�`�F�b�N�f�[�^�i�荞�ݗp�j���擾����
     *
     * @return �S����ID�i�`�F�b�N�f�[�^�i�荞�ݗp�j
     */
    public String getHAMID()
    {
        return _HAMID;
    }

    /**
     * �S����ID�i�`�F�b�N�f�[�^�i�荞�ݗp�j��ݒ肷��
     *
     * @param val �S����ID�i�`�F�b�N�f�[�^�i�荞�ݗp�j
     */
    public void setHAMID(String val)
    {
        _HAMID = val;
    }

}
