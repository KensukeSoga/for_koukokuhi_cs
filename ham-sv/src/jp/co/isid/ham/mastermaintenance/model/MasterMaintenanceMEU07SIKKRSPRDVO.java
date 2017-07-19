package jp.co.isid.ham.mastermaintenance.model;

import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.nj.model.AbstractModel;

/**
 * <P>
 * �o���g�D�W�J�e�[�u���f�[�^VO
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2013/05/02 �X)<BR>
 * </P>
 * @author �X
 */
@XmlRootElement(namespace = "http://model.mastermaintenance.ham.isid.co.jp/")
@XmlType(namespace = "http://model.mastermaintenance.ham.isid.co.jp/")
public class MasterMaintenanceMEU07SIKKRSPRDVO extends AbstractModel
{
    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** �g�D�R�[�h */
    private String _SIKCD    = null;

    /** �L���I���N���� */
    private String _ENDYMD   = null;

    /** �L���J�n�N���� */
    private String _STARTYMD = null;

    /** �\�����i�����j */
    private String _HYOJIKJ  = null;

    /** �Ǖ\�����i�����j */
    private String _KYKHYOJIKJ  = null;

    /** ���\�����i�����j */
    private String _SITUHYOJIKJ  = null;

    /** ���\�����i�����j */
    private String _BUHYOJIKJ  = null;

    /** �ە\�����i�����j */
    private String _KAHYOJIKJ  = null;

    /**
     * �f�t�H���g�R���X�g���N�^
     */
    public MasterMaintenanceMEU07SIKKRSPRDVO()
    {
    }

    /**
     * �V�K�C���X�^���X�𐶐�����
     *
     * @return �V�K�C���X�^���X
     */
    public Object newInstance()
    {
        return new MasterMaintenanceMEU07SIKKRSPRDVO();
    }

    /**
     * �g�D�R�[�h���擾����
     *
     * @return �g�D�R�[�h
     */
    public String getSIKCD()
    {
        return _SIKCD;
    }

    /**
     * �g�D�R�[�h��ݒ肷��
     *
     * @param val �g�D�R�[�h
     */
    public void setSIKCD(String val)
    {
        _SIKCD = val;
    }

    /**
     * �L���I���N�������擾����
     *
     * @return �L���I���N����
     */
    public String getENDYMD()
    {
        return _ENDYMD;
    }

    /**
     * �L���I���N������ݒ肷��
     *
     * @param val �L���I���N����
     */
    public void setENDYMD(String val)
    {
        _ENDYMD = val;
    }

    /**
     * �L���J�n�N�������擾����
     *
     * @return �L���J�n�N����
     */
    public String getSTARTYMD()
    {
        return _STARTYMD;
    }

    /**
     * �L���J�n�N������ݒ肷��
     *
     * @param val �L���J�n�N����
     */
    public void setSTARTYMD(String val)
    {
        _STARTYMD = val;
    }

    /**
     * �\�����i�����j���擾����
     *
     * @return �\�����i�����j
     */
    public String getHYOJIKJ()
    {
        return _HYOJIKJ;
    }

    /**
     * �\�����i�����j��ݒ肷��
     *
     * @param val �\�����i�����j
     */
    public void setHYOJIKJ(String val)
    {
        _HYOJIKJ = val;
    }

    /**
     * �Ǖ\�����i�����j���擾����
     *
     * @return �Ǖ\�����i�����j
     */
    public String getKYKHYOJIKJ()
    {
        return _KYKHYOJIKJ;
    }

    /**
     * �Ǖ\�����i�����j��ݒ肷��
     *
     * @param val �Ǖ\�����i�����j
     */
    public void setKYKHYOJIKJ(String val)
    {
        _KYKHYOJIKJ = val;
    }

    /**
     * ���\�����i�����j���擾����
     *
     * @return ���\�����i�����j
     */
    public String getSITUHYOJIKJ()
    {
        return _SITUHYOJIKJ;
    }

    /**
     * ���\�����i�����j��ݒ肷��
     *
     * @param val ���\�����i�����j
     */
    public void setSITUHYOJIKJ(String val)
    {
        _SITUHYOJIKJ = val;
    }

    /**
     * ���\�����i�����j���擾����
     *
     * @return ���\�����i�����j
     */
    public String getBUHYOJIKJ()
    {
        return _BUHYOJIKJ;
    }

    /**
     * ���\�����i�����j��ݒ肷��
     *
     * @param val ���\�����i�����j
     */
    public void setBUHYOJIKJ(String val)
    {
        _BUHYOJIKJ = val;
    }

    /**
     * �ە\�����i�����j���擾����
     *
     * @return �ە\�����i�����j
     */
    public String getKAHYOJIKJ()
    {
        return _KAHYOJIKJ;
    }

    /**
     * �ە\�����i�����j��ݒ肷��
     *
     * @param val �ە\�����i�����j
     */
    public void setKAHYOJIKJ(String val)
    {
        _KAHYOJIKJ = val;
    }

}
