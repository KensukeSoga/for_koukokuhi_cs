package jp.co.isid.ham.media.model;

import java.util.List;

import jp.co.isid.ham.integ.tbl.Mbj03Media;
import jp.co.isid.ham.integ.tbl.Mbj05Car;
import jp.co.isid.ham.integ.tbl.Mbj10MediaSec;
import jp.co.isid.ham.integ.tbl.Mbj11CarSec;
import jp.co.isid.ham.integ.tbl.Mbj13CarOutCtrl;
import jp.co.isid.ham.integ.tbl.Mbj14MediaOutCtrl;
import jp.co.isid.ham.integ.tbl.Tbj02EigyoDaicho;
import jp.co.isid.ham.integ.util.HAMPoolConnect;
import jp.co.isid.ham.model.HAMOracleModel;
import jp.co.isid.ham.model.base.HAMException;
import jp.co.isid.nj.exp.UserException;
import jp.co.isid.nj.integ.sql.AbstractSimpleRdbDao;

public class FindBillStatementDataDAO extends AbstractSimpleRdbDao {

    /** �f�[�^�������� */
    private FindBillStatementDataCondition _cond = null;

    /**
     * �f�t�H���g�R���X�g���N�^
     */
    public FindBillStatementDataDAO() {
        super.setPoolConnectClass(HAMPoolConnect.class);
        super.setDBModelInterface(HAMOracleModel.getInstance());
        super.setBigDecimalMode(true);
    }

    /**
     * �v���C�}���L�[���擾����
     *
     * @return String[] �v���C�}���L�[
     */
    public String[] getPrimryKeyNames() {
        return new String[] {
                Tbj02EigyoDaicho.MEDIAPLANNO
                ,Tbj02EigyoDaicho.DAICHONO
        };
    }

    /**
     * �X�V���t�t�B�[���h���擾����
     *
     * @return String �X�V���t�t�B�[���h
     */
    public String getTimeStampKeyName() {
        return Tbj02EigyoDaicho.UPDDATE;
    }

    /**
     * �V�X�e�����t�ōX�V���s���J�������̔z����擾����
     *
     * @return �V�X�e�����t�ōX�V���s���J�������̔z��
     */
    @Override
    public String[] getSystemDateColumnNames() {
        return new String[] {
                Tbj02EigyoDaicho.CRTDATE
                ,Tbj02EigyoDaicho.UPDDATE
        };
    }

    /**
     * �e�[�u�������擾����
     *
     * @return String �e�[�u����
     */
    public String getTableName() {
        return Tbj02EigyoDaicho.TBNAME;
    }

    /**
     * �e�[�u���񖼂��擾����
     *
     * @return String[] �e�[�u����
     */
    public String[] getTableColumnNames() {
        return new String[] {
                Tbj02EigyoDaicho.MEDIAPLANNO
                ,Tbj02EigyoDaicho.DAICHONO
                ,Tbj02EigyoDaicho.IMPKEY
                ,Tbj02EigyoDaicho.SEIKYUYM
                ,Tbj02EigyoDaicho.MEDIACD
                ,Tbj02EigyoDaicho.MEDIASCD
                ,Tbj02EigyoDaicho.MEDIASNM
                ,Tbj02EigyoDaicho.KEIRETSUCD
                ,Tbj02EigyoDaicho.DCARCD
                ,Tbj02EigyoDaicho.HIYOUNO
                ,Tbj02EigyoDaicho.KIKAKUNO
                ,Tbj02EigyoDaicho.CAMPAIGN
                ,Tbj02EigyoDaicho.NAIYOHIMOKU
                ,Tbj02EigyoDaicho.SPACE
                ,Tbj02EigyoDaicho.NPDIVISION
                ,Tbj02EigyoDaicho.PUBLISHVER
                ,Tbj02EigyoDaicho.SYMBOLDIVISION
                ,Tbj02EigyoDaicho.POSTEDSURFACE
                ,Tbj02EigyoDaicho.UNIT
                ,Tbj02EigyoDaicho.CONTRACTDIVISION
                ,Tbj02EigyoDaicho.KIKANFROM
                ,Tbj02EigyoDaicho.KIKANTO
                ,Tbj02EigyoDaicho.GENKAFLG
                ,Tbj02EigyoDaicho.GROSS
                ,Tbj02EigyoDaicho.DNEBIKIRITSU
                ,Tbj02EigyoDaicho.DNEBIKIGAKU
                ,Tbj02EigyoDaicho.HMCOST
                ,Tbj02EigyoDaicho.APLRIEKIRITSU
                ,Tbj02EigyoDaicho.APLRIEKIGAKU
                ,Tbj02EigyoDaicho.MEDIAHARAI
                ,Tbj02EigyoDaicho.MEDIAMARGINRITSU
                ,Tbj02EigyoDaicho.MEDIAMARGINGAKU
                ,Tbj02EigyoDaicho.MEDIAGENKA
                ,Tbj02EigyoDaicho.TORIRIEKI
                ,Tbj02EigyoDaicho.RIEKIHAIBUN
                ,Tbj02EigyoDaicho.NAIKINRIEKI
                ,Tbj02EigyoDaicho.FURIKAERIEKI
                ,Tbj02EigyoDaicho.EIGYOYOIN
                ,Tbj02EigyoDaicho.FURIKAERIEKI2
                ,Tbj02EigyoDaicho.TVTMEDIATANKA
                ,Tbj02EigyoDaicho.TVTHMTANKA
                ,Tbj02EigyoDaicho.COLORFEE
                ,Tbj02EigyoDaicho.DESIGNATIONFEE
                ,Tbj02EigyoDaicho.DOUBLEFEE
                ,Tbj02EigyoDaicho.RECLASSIFICATIONFEE
                ,Tbj02EigyoDaicho.SPACEFEE
                ,Tbj02EigyoDaicho.SPLITRUNFEE
                ,Tbj02EigyoDaicho.REQUESTDESTINATION
                ,Tbj02EigyoDaicho.BRDDATE
                ,Tbj02EigyoDaicho.BIKO
                ,Tbj02EigyoDaicho.SEIKYUFLG
                ,Tbj02EigyoDaicho.CPDATE
                ,Tbj02EigyoDaicho.BRDSEC
                ,Tbj02EigyoDaicho.FILEOUTFLG
                ,Tbj02EigyoDaicho.CRTDATE
                ,Tbj02EigyoDaicho.CRTNM
                ,Tbj02EigyoDaicho.CRTAPL
                ,Tbj02EigyoDaicho.CRTID
                ,Tbj02EigyoDaicho.UPDDATE
                ,Tbj02EigyoDaicho.UPDNM
                ,Tbj02EigyoDaicho.UPDAPL
                ,Tbj02EigyoDaicho.UPDID
                ,Mbj03Media.MEDIANM
                ,Mbj05Car.CARNM
                ,Mbj13CarOutCtrl.SORTNO
                ,Mbj14MediaOutCtrl.SORTNO
        };
    }

    /**
     * SELECT SQL
     */
    @Override
    public String getSelectSQL() {

        return getBillOutputData();
    }

    /**
     * �������׏��o�͏����Ō������s��
     * @return SQL��
     */
    private String getBillOutputData() {
        StringBuffer sql = new StringBuffer();
        sql.append(" SELECT");
        //�S���ڂ��擾
        for (int i = 0; i < getTableColumnNames().length; i++) {
            if (i == 0) {
                sql.append("  " + getTableColumnNames()[i] + " ");
            } else {
                sql.append(" ," + getTableColumnNames()[i] + " ");
            }
        }
        sql.append(" FROM ");
        sql.append(" " + getTableName() + ", ");
        sql.append(" " + Mbj03Media.TBNAME + ", ");
        sql.append(" " + Mbj05Car.TBNAME + ", ");
        sql.append(" " + Mbj10MediaSec.TBNAME + ", ");
        sql.append(" " + Mbj11CarSec.TBNAME + ", ");
        sql.append(" " + Mbj13CarOutCtrl.TBNAME + ", ");
        sql.append(" " + Mbj14MediaOutCtrl.TBNAME + " ");
        sql.append(" ,( ");
        sql.append(" SELECT");
        sql.append(" " + Tbj02EigyoDaicho.MEDIASNM + " AS MEDIASNM, ");
        sql.append(" SUM(" + Tbj02EigyoDaicho.HMCOST + ") AS HMCOST_SUM ");
        sql.append(" FROM ");
        sql.append(" " + getTableName() + ", ");
        sql.append(" " + Mbj03Media.TBNAME + ", ");
        sql.append(" " + Mbj05Car.TBNAME + ", ");
        sql.append(" " + Mbj10MediaSec.TBNAME + ", ");
        sql.append(" " + Mbj11CarSec.TBNAME + ", ");
        sql.append(" " + Mbj13CarOutCtrl.TBNAME + ", ");
        sql.append(" " + Mbj14MediaOutCtrl.TBNAME + " ");
        sql.append(" WHERE ");
        sql.append(" " + Tbj02EigyoDaicho.MEDIACD + " = " + Mbj03Media.MEDIACD + "(+)" );
        sql.append(" AND ");
        sql.append(" " + Tbj02EigyoDaicho.DCARCD + " = " +Mbj05Car.DCARCD + "(+)" );
        sql.append(" AND ");
        sql.append(" " + Mbj03Media.MEDIACD + " = " + Mbj10MediaSec.MEDIACD + "(+)" );
        sql.append(" AND ");
        sql.append(" " + Mbj05Car.DCARCD + " = " +Mbj11CarSec.DCARCD + "(+)" );
        sql.append(" AND ");
        sql.append(" " + Tbj02EigyoDaicho.MEDIACD + " = " + Mbj14MediaOutCtrl.MEDIACD + " ");
        sql.append(" AND ");
        sql.append(" " + Tbj02EigyoDaicho.DCARCD + " = " + Mbj13CarOutCtrl.DCARCD + " ");
        sql.append(" AND ");
        sql.append(" TRUNC(" + Tbj02EigyoDaicho.SEIKYUYM + ", 'MM') = TRUNC(TO_DATE('" + _cond.getKikanfrom() + "','YYYY/MM/DD'), 'MM') ");
        sql.append(" AND ");
        //false�������Ă����ꍇ�̂݁A�����ΏۊO�t���O�������ĂȂ����̂���������
        //true�̏ꍇ�͑S�Č�������
        if (!_cond.getSeikyuflg()) {
            sql.append(" " + Tbj02EigyoDaicho.SEIKYUFLG + "= '0'");
            sql.append(" AND ");
        }
        sql.append(" " + Mbj10MediaSec.AUTHORITY + " > '0'" );
        sql.append(" AND ");
        sql.append(" " + Mbj11CarSec.AUTHORITY + " > '0'" );
        sql.append(" AND ");
        sql.append(" " + Mbj10MediaSec.HAMID + " = '" + _cond.getHamid() +"' ");
        sql.append(" AND ");
        sql.append(" " + Mbj11CarSec.HAMID + " = '" + _cond.getHamid() +"' ");
        sql.append(" AND ");
        sql.append(" " + Mbj11CarSec.SECTYPE + " = '0' ");
        sql.append(" AND ");
        sql.append(" " + Mbj13CarOutCtrl.OUTPUTFLG + " = '1' "); //1�͏o�͑Ώ�
        sql.append(" AND ");
        sql.append(" " + Mbj14MediaOutCtrl.OUTPUTFLG + " = '1' ");
        sql.append(" AND ");
        sql.append(" " + Mbj13CarOutCtrl.PHASE + " = " + _cond.getPhase() + " ");
        sql.append(" AND ");
        sql.append(" " + Mbj14MediaOutCtrl.PHASE + " = " + _cond.getPhase() + " ");
        sql.append(" AND ");
        sql.append(" " + Mbj13CarOutCtrl.REPORTCD + " = 'R03' "); //�������׏��̏o�͐ݒ�
        sql.append(" AND ");
        sql.append(" " + Mbj14MediaOutCtrl.REPORTCD + " = 'R03' ");
        sql.append(" GROUP BY ");
        sql.append(" " + Tbj02EigyoDaicho.MEDIASNM + " ");
        sql.append(" ) SUM_TABLE ");
        sql.append(" WHERE ");
        sql.append(" " + Tbj02EigyoDaicho.MEDIACD + " = " + Mbj03Media.MEDIACD + "(+)" );
        sql.append(" AND ");
        sql.append(" " + Tbj02EigyoDaicho.DCARCD + " = " +Mbj05Car.DCARCD + "(+)" );
        sql.append(" AND ");
        sql.append(" " + Mbj03Media.MEDIACD + " = " + Mbj10MediaSec.MEDIACD + "(+)" );
        sql.append(" AND ");
        sql.append(" " + Mbj05Car.DCARCD + " = " +Mbj11CarSec.DCARCD + "(+)" );
        sql.append(" AND ");
        sql.append(" " + Tbj02EigyoDaicho.MEDIACD + " = " + Mbj14MediaOutCtrl.MEDIACD + " ");
        sql.append(" AND ");
        sql.append(" " + Tbj02EigyoDaicho.DCARCD + " = " + Mbj13CarOutCtrl.DCARCD + " ");
//        sql.append(" AND ");
//        sql.append(" " + Tbj02EigyoDaicho.KIKANFROM + " >= TO_DATE('" + _cond.getKikanfrom() + "','YYYY/MM/DD') ");
//        sql.append(" AND ");
//        sql.append(" " + Tbj02EigyoDaicho.KIKANTO + " <= TO_DATE('" + _cond.getKikanto() + "','YYYY/MM/DD') ");
        sql.append(" AND ");
        sql.append(" TRUNC(" + Tbj02EigyoDaicho.SEIKYUYM + ", 'MM') = TRUNC(TO_DATE('" + _cond.getKikanfrom() + "','YYYY/MM/DD'), 'MM') ");
        sql.append(" AND ");
        //false�������Ă����ꍇ�̂݁A�����ΏۊO�t���O�������ĂȂ����̂���������
        //true�̏ꍇ�͑S�Č�������
        if (!_cond.getSeikyuflg()) {
            sql.append(" " + Tbj02EigyoDaicho.SEIKYUFLG + "= '0'");
            sql.append(" AND ");
        }
        sql.append(" " + Mbj10MediaSec.AUTHORITY + " > '0'" );
        sql.append(" AND ");
        sql.append(" " + Mbj11CarSec.AUTHORITY + " > '0'" );
        sql.append(" AND ");
        sql.append(" " + Mbj10MediaSec.HAMID + " = '" + _cond.getHamid() +"' ");
        sql.append(" AND ");
        sql.append(" " + Mbj11CarSec.HAMID + " = '" + _cond.getHamid() +"' ");
        sql.append(" AND ");
        sql.append(" " + Mbj11CarSec.SECTYPE + " = '0' ");
        sql.append(" AND ");
        sql.append(" " + Mbj13CarOutCtrl.OUTPUTFLG + " = '1' "); //1�͏o�͑Ώ�
        sql.append(" AND ");
        sql.append(" " + Mbj14MediaOutCtrl.OUTPUTFLG + " = '1' ");
        sql.append(" AND ");
        sql.append(" " + Mbj13CarOutCtrl.PHASE + " = " + _cond.getPhase() + " ");
        sql.append(" AND ");
        sql.append(" " + Mbj14MediaOutCtrl.PHASE + " = " + _cond.getPhase() + " ");
        sql.append(" AND ");
        sql.append(" " + Mbj13CarOutCtrl.REPORTCD + " = 'R03' "); //�������׏��̏o�͐ݒ�
        sql.append(" AND ");
        sql.append(" " + Mbj14MediaOutCtrl.REPORTCD + " = 'R03' ");
        sql.append(" AND ");
        sql.append(" " + Mbj14MediaOutCtrl.REPORTCD + " = 'R03' ");
        sql.append(" AND ");
        sql.append(" " + Tbj02EigyoDaicho.MEDIASNM + " = MEDIASNM(+) ");
        sql.append(" ORDER BY ");
        sql.append(" " + Mbj14MediaOutCtrl.SORTNO + " ASC, ");
        sql.append(" " + Mbj14MediaOutCtrl.MEDIACD + " ASC, ");
//        sql.append(" " + Mbj13CarOutCtrl.SORTNO + " ASC, ");
//        sql.append(" " + Mbj13CarOutCtrl.DCARCD + " ASC, ");
        //sql.append(" " + Tbj02EigyoDaicho.DAICHONO + " ASC ");
        sql.append(" CASE " + Tbj02EigyoDaicho.MEDIACD);
        sql.append("     WHEN 'M01' THEN " + " NULL ");//�V��
        sql.append("     WHEN 'M02' THEN " + " NULL ");//�G��
        sql.append("     WHEN 'M03' THEN " + " NULL ");//�e���r�^�C��
        sql.append("     WHEN 'M04' THEN " + " NULL ");//�e���r�X�|�b�g
        sql.append("     WHEN 'M05' THEN " + " NULL ");//���W�I�^�C��
        sql.append("     WHEN 'M06' THEN " + " NULL ");//���W�I�X�|�b�g
        sql.append("     WHEN 'M07' THEN " + "HMCOST_SUM ");//�C���^�[�l�b�g
        sql.append("     WHEN 'M08' THEN " + " NULL ");//CS
        sql.append("     WHEN 'M09' THEN " + " NULL ");//BS�X�|�b�g
        sql.append("     WHEN 'M10' THEN " + " NULL ");//OOH
        sql.append("     WHEN 'M11' THEN " + " NULL ");//BS�^�C��
        sql.append("     ELSE NULL ");//���̑��}��
        sql.append(" END DESC , ");
        sql.append(" CASE " + Tbj02EigyoDaicho.MEDIACD);
        sql.append("     WHEN 'M01' THEN " + Tbj02EigyoDaicho.CAMPAIGN);//�V��
        sql.append("     WHEN 'M02' THEN " + "UPPER(" + Tbj02EigyoDaicho.MEDIASNM + ")");//�G��
        sql.append("     WHEN 'M03' THEN " + Tbj02EigyoDaicho.CAMPAIGN);//�e���r�^�C��
        sql.append("     WHEN 'M04' THEN " + Tbj02EigyoDaicho.CAMPAIGN);//�e���r�X�|�b�g
        sql.append("     WHEN 'M05' THEN " + Tbj02EigyoDaicho.CAMPAIGN);//���W�I�^�C��
        sql.append("     WHEN 'M06' THEN " + Tbj02EigyoDaicho.CAMPAIGN);//���W�I�X�|�b�g
        sql.append("     WHEN 'M07' THEN " + "UPPER(" + Tbj02EigyoDaicho.MEDIASNM + ")");//�C���^�[�l�b�g
        sql.append("     WHEN 'M08' THEN " + "UPPER(" + Tbj02EigyoDaicho.MEDIASNM + ")");//CS
        sql.append("     WHEN 'M09' THEN " + "UPPER(" + Tbj02EigyoDaicho.MEDIASNM + ")");//BS�X�|�b�g
        sql.append("     WHEN 'M10' THEN " + "UPPER(" + Tbj02EigyoDaicho.MEDIASNM + ")");//OOH
        sql.append("     WHEN 'M11' THEN " + Tbj02EigyoDaicho.CAMPAIGN);//BS�^�C��
        sql.append("     ELSE TO_CHAR(" + Tbj02EigyoDaicho.KIKANFROM + ")");//���̑��}��
        sql.append(" END , ");
        sql.append(" CASE " + Tbj02EigyoDaicho.MEDIACD);
        sql.append("     WHEN 'M01' THEN " + " NULL ");//�V��
        sql.append("     WHEN 'M02' THEN " + " NULL ");//�G��
        sql.append("     WHEN 'M03' THEN " + " NULL ");//�e���r�^�C��
        sql.append("     WHEN 'M04' THEN " + " NULL ");//�e���r�X�|�b�g
        sql.append("     WHEN 'M05' THEN " + Tbj02EigyoDaicho.DAICHONO);//���W�I�^�C��
        sql.append("     WHEN 'M06' THEN " + " NULL ");//���W�I�X�|�b�g
        sql.append("     WHEN 'M07' THEN " + Tbj02EigyoDaicho.NAIYOHIMOKU);//�C���^�[�l�b�g
        sql.append("     WHEN 'M08' THEN " + " NULL ");//CS
        sql.append("     WHEN 'M09' THEN " + " NULL ");//BS�X�|�b�g
        sql.append("     WHEN 'M10' THEN " + Tbj02EigyoDaicho.NAIYOHIMOKU);//OOH
        sql.append("     WHEN 'M11' THEN " + " NULL ");//BS�^�C��
        sql.append("     ELSE NULL ");//���̑��}��
        sql.append(" END , ");
        sql.append(" CASE " + Tbj02EigyoDaicho.MEDIACD);
        sql.append("     WHEN 'M01' THEN " + " NULL ");//�V��
        sql.append("     WHEN 'M02' THEN " + " NULL ");//�G��
        sql.append("     WHEN 'M03' THEN " + " NULL ");//�e���r�^�C��
        sql.append("     WHEN 'M04' THEN " + " NULL ");//�e���r�X�|�b�g
        sql.append("     WHEN 'M05' THEN " + " NULL ");//���W�I�^�C��
        sql.append("     WHEN 'M06' THEN " + " NULL ");//���W�I�X�|�b�g
        sql.append("     WHEN 'M07' THEN TO_CHAR(" + Tbj02EigyoDaicho.KIKANFROM + ")");//�C���^�[�l�b�g
        sql.append("     WHEN 'M08' THEN " + " NULL ");//CS
        sql.append("     WHEN 'M09' THEN " + " NULL ");//BS�X�|�b�g
        sql.append("     WHEN 'M10' THEN TO_CHAR(" + Tbj02EigyoDaicho.KIKANFROM + ")");//OOH
        sql.append("     WHEN 'M11' THEN " + " NULL ");//BS�^�C��
        sql.append("     ELSE NULL ");//���̑��}��
        sql.append(" END ");

        return sql.toString();
    }

    /**
     * �������׏��o�͏��̌������s���܂�
     *
     * @return �������׏��o�͏��VO���X�g
     * @throws UserException
     *             �f�[�^�A�N�Z�X���ɃG���[�����������ꍇ
     */
    @SuppressWarnings("unchecked")
    public List<FindBillStatementDataVO> findBillOutputData(FindBillStatementDataCondition cond) throws HAMException {

        super.setModel(new FindBillStatementDataVO());

        try {
            _cond = cond;
            return super.find();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0001");
        }
    }

}
