package jp.co.isid.ham.util;

import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.util.ArrayList;
import java.util.Calendar;
import java.util.Date;
import java.util.List;

import jp.co.isid.ham.util.constants.HAMConstants;
import jp.co.isid.nj.model.DummyNull;

/**
 * <P>
 * ���t�Ɋւ��郆�[�e�B���e�B�N���X
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2011/01/07 ISID-IT K.Nukita)<BR>
 * �E�ǉ�(2012//06/07 JSE K.Tamura) format�̃p�^�[���̔ėp��<BR>
 * �E�����Ɩ��ύX�Ή�(2015/08/31 HLC S.Fujimoto)<BR>
 * �E�����Ɩ��ύX�s��Ή�(2016/03/16 HLC K.Soga)<BR>
 * </P>
 * @author ISID-IT K.Nukita
 */
public class DateUtil {

    /**
     * String��Date�^�ϊ�����
     *
     * @param strDate �W���̓��t������(YYYYMMDD)
     * @return Date ���t
     */
    public static Date toDate(String dateString) {
        try {
            SimpleDateFormat format = new SimpleDateFormat("yyyyMMdd");
            return format.parse(dateString);
        } catch (ParseException e) {
            return null;
        }
    }

    /**
     * String��Date�^�ϊ�����(�ėp��)
     *
     * @param strDate ���ԕ�����
     * @param pattern �`��
     * @return Date
     * @author K.Tamura
     */
    public static Date toDateGeneral(String dateString, String pattern) {
        try {
            SimpleDateFormat format = new SimpleDateFormat(pattern);
            return format.parse(dateString);
        } catch (ParseException e) {
            return null;
        }
    }

    /**
     * Date��String�^�ϊ�����
     *
     * @param date ���t
     * @return String �W���̓��t������(YYYYMMDD)
     */
    public static String toString(Date date) {
        SimpleDateFormat format = new SimpleDateFormat("yyyyMMdd");
        return format.format(date);
    }

    /**
     * Date��String�^�ϊ�����(�ėp��)
     *
     * @param date ����
     * @param pattern �`��
     * @return String ���ԕ�����
     * @author K.Tamura
     */
    public static String toStringGeneral(Date date, String pattern) {
        SimpleDateFormat format = new SimpleDateFormat(pattern);
        return format.format(date);
    }


    /**
     * ���t�Ɏw�肳�ꂽ���������Z���܂�
     *
     * @param dateString ���t
     * @param count ���Z�������
     * @return
     */
    public static String addDate(String dateString ,int count) {

        Date date = toDate(dateString);

        Calendar cal = Calendar.getInstance();
        cal.setTime(date);
        cal.add(Calendar.DATE, count);

        return toString(cal.getTime());
    }

    /** 2016/04/12 HDX�Ή� HLC K.Soga ADD Start */
    /**
     * �N�Ɏw�肳�ꂽ�N�������Z���܂�
     *
     * @param yearString �N
     * @param count ���Z����N��
     * @return
     */
    public static String addYear(String yearString ,int count) {

        Date date = toDate(yearString);

        Calendar cal = Calendar.getInstance();
        cal.setTime(date);
        cal.add(Calendar.YEAR, count);

        return toString(cal.getTime());
    }
    /** 2016/04/12 HDX�Ή� HLC K.Soga ADD End */

    /**
     * �V�X�e�����t���w��̃t�H�[�}�b�g�Ŗ߂�<br>
     * �y�}��z<br>
     *   yyyy�F����4��<br>
     *   MM�F��2��<br>
     *   dd�F��2��<br>
     *   HH�F��(24���ԕ\�L)<br>
     *   hh�F��(12���ԕ\�L)<br>
     *   mm�F��2��<br>
     *   ss�F�b2��<br>
     *   SSS�F�~���b3��<br>
     *
     * @param dateString String ���t
     * @param targetFormat String �o�̓t�H�[�}�b�g (��D��P�F"yyyy/MM/dd"�A��Q�F"HH:mm"�A��R�F"yyyy/MM/dd HH:mm:ss.SSS")
     * @return String �ϊ��㕶���� (��P�F"2007/08/05"�A��Q�F"15:30"�A��R�F"2008/03/22 15:24:10.876")
     */
    public static String getFormatStringDate(String dateString, String targetFormat) {
        Date date = toDate(dateString);
        return new SimpleDateFormat(targetFormat).format(date);
    }

    /**
     * ����From(yyyyMMdd)�`����To(yyyyMMdd)�܂ł̔N�̃��X�g���擾���܂�
     *
     * @param termFrom String ����From
     * @param termTo String ����To
     * @return List<String> �N�̃��X�g
     */
    public static List<String> getYearList(String termFrom, String termTo) {

        Date dateFrom = toDate(termFrom);
        Date dateTo = toDate(termTo);
        Calendar calFrom = Calendar.getInstance();
        Calendar calTo = Calendar.getInstance();

        calFrom.setTime(dateFrom);
        calTo.setTime(dateTo);

        List<String> yearList = new ArrayList<String>();

        while (calFrom.get(Calendar.YEAR) <= calTo.get(Calendar.YEAR)) {
            yearList.add(String.valueOf(calFrom.get(Calendar.YEAR)));
            calFrom.add(Calendar.YEAR, 1);
        }

        return yearList;
    }

    /**
     * ����擾
     *
     * @param eigyoBi �z�X�g�c�Ɠ�
     * @return ����
     */
    public static String getTermBegin(String eigyoBi) {

        int year = Integer.parseInt(eigyoBi.substring(0, 4));
        int month = Integer.parseInt(eigyoBi.substring(4, 6));

        if (month >= 1 && month <= 3) {
            year = year - 1;
        }
        return Integer.toString(year) + "04";
    }

    /**
     * �����擾
     *
     * @param eigyoBi �z�X�g�c�Ɠ�
     * @return ����
     */
    public static String getTermEnd(String eigyoBi) {

        int year = Integer.parseInt(eigyoBi.substring(0, 4));
        int month = Integer.parseInt(eigyoBi.substring(4, 6));

        if (month >= 4 && month <= 12) {
            year = year + 1;
        }
        return Integer.toString(year) + "03";
    }

    /**
     * �w�肵���p�����[�^����t�^�ɕϊ����܂�
     * @param val �ΏۃI�u�W�F�N�g
     * @return �����A�܂���null
     */
    public static Date toDateForNull(Object val) {

        Date dt = null;

        try {
            if (!(val instanceof DummyNull)) {
                dt = (Date)val;
            }
        } catch(Exception ex) {
            dt = null;
        }

        return dt;
    }

    /**
     * �w�肵��2�̓��t�̍��������擾���܂�
     * @param from
     * @param to
     * @return
     */
    public static long getTermDays(Date from, Date to) {

        long days = 0;
        long difference = 0;

        if (from.compareTo(to) <= 0) {
            difference = to.getTime() - from.getTime();
        } else {
            difference = from.getTime() - to.getTime();
        }
        days = difference / 1000 / 60 / 60 / 24;

        return days;
    }

    /** 2015/08/31 �����Ɩ��ύX�Ή� HLC S.Fujimoto ADD Start */
    /**
     * ���擾����
     * @param yearMonth �N��(YYYY/MM)
     * @return ��
     */
    public static String getTerm(String yearMonth) {

        //�N���̌����擾
        int month = Integer.valueOf(yearMonth.substring(5, 7));

        if ((4 <= month) && (month <= 9)) {
            // ���
            return HAMConstants.TERM_FIRST;
        } else {
            // ����
            return HAMConstants.TERM_SECOND;
        }
    }
    /** 2015/08/31 �����Ɩ��ύX�Ή� HLC S.Fujimoto ADD End */

    /** 2016/03/15 �����Ɩ��ύX�s��Ή� HLC K.Soga ADD Start */
    /**
     * �O���Z�o
     * @param yearMonth �N��(YYYY/MM)
     * @return ��
     */
    public static String getPrevMonth(String yearMonth) {
        String year = yearMonth.substring(0, 4);
        String month = yearMonth.substring(5, 7);

        //1���̏ꍇ.
        if (Integer.parseInt(month) == 1) {
            //�O�N12���ɃZ�b�g
            return yearMonth = String.format("%04d", Integer.parseInt(year) - 1) + String.format("%02d", 12);
        } else {
            //�O���ɃZ�b�g.
            return yearMonth = year + String.format("%02d", Integer.parseInt(month) - 1);
        }
    }
    /** 2016/03/15 �����Ɩ��ύX�s��Ή� HLC K.Soga ADD End */
}